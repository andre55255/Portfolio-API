using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using Portfolio.Infrastructure.Data.Sql.Context;

namespace Portfolio.Infrastructure.RepositoriesImpl.Sql
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly SqlDbContext _db;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public ProjectRepository(SqlDbContext db, ILogService logService, IMapper mapper)
        {
            _db = db;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return
                    await _db.Projects
                             .Where(x => x.DisabledAt == null)
                             .CountAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar quantidade de itens na tabela de projetos", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar quantidade de itens na tabela de projetos", ex);
            }
        }

        public async Task<ListAllEntityVO<Project>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<Project> response = new ListAllEntityVO<Project>();
                response.TotalItems = await CountAsync();

                if (response.TotalItems <= 0)
                    return response;

                StaticMethods.GetPaginationItems(ref response, ref limit, ref page);

                response.Items =
                    await _db.Projects
                             .Where(x => x.DisabledAt == null)
                             .Include(x => x.Portfolio)
                             .OrderByDescending(x => x.UpdatedAt)
                             .ThenBy(x => x.Title)
                             .Skip(limit.Value * page.Value)
                             .Take(limit.Value)
                             .AsNoTracking()
                             .ToListAsync();

                return response;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar projetos da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar projetos da base de dados", ex);
            }
        }

        public async Task<List<Project>> GetAllByPortfolioIdAsync(int portfolioId)
        {
            try
            {
                return
                    await _db.Projects
                             .Where(x => x.DisabledAt == null &&
                                         x.PortfolioId == portfolioId)
                             .Include(x => x.Portfolio)
                             .OrderByDescending(x => x.UpdatedAt)
                             .ThenBy(x => x.Title)
                             .AsNoTracking()
                             .ToListAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar projetos do portfolio {portfolioId} da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao projetos contatos do portfolio {portfolioId} tda base de dados", ex);
            }
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            try
            {
                return
                    await _db.Projects
                             .Where(x => x.DisabledAt == null &&
                                         x.Id == id)
                             .Include(x => x.Portfolio)
                             .FirstOrDefaultAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar projeto pelo id {id} da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar projeto pelo id {id} tda base de dados", ex);
            }
        }

        public async Task<Project> InsertAsync(Project model)
        {
            try
            {
                model.Id = 0;

                _db.Projects.Add(model);
                await _db.SaveChangesAsync();

                return await GetByIdAsync(model.Id);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao inserir projeto {model.Title} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao inserir projeto {model.Title} na base de dados", ex);
            }
        }

        public async Task<Project> RemoveAsync(int id)
        {
            try
            {
                Project save = await GetByIdAsync(id);
                if (save == null)
                    throw new RepositoryException($"Não foi encontrado um projeto com o id {id}");

                save.DisabledAt = DateTime.Now;
                await _db.SaveChangesAsync();

                return save;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao remover projeto {id} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao remover projeto {id} na base de dados", ex);
            }
        }

        public async Task<Project> UpdateAsync(Project model)
        {
            try
            {
                Project? save =
                    await _db.Projects
                             .Where(x => x.Id == model.Id &&
                                         x.DisabledAt == null)
                             .FirstOrDefaultAsync();

                if (save == null)
                    throw new RepositoryException($"Não foi encontrado um projeto com o id {model.Id}");

                model.CreatedAt = save.CreatedAt;
                model.UpdatedAt = DateTime.Now;

                _mapper.Map(model, save);
                await _db.SaveChangesAsync();

                return await GetByIdAsync(model.Id);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao editar projeto {model.Id} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao editar projeto {model.Id} na base de dados", ex);
            }
        }
    }
}
