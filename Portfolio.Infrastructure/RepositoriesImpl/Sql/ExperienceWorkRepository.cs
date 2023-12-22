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
    public class ExperienceWorkRepository : IExperienceWorkRepository
    {
        private readonly SqlDbContext _db;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo;
        private readonly ILogService _logService;

        public ExperienceWorkRepository(SqlDbContext db, IMapper mapper, ILogService logService, IUserRepository userRepo)
        {
            _db = db;
            _mapper = mapper;
            _logService = logService;
            _userRepo = userRepo;
        }

        public async Task<int> CountAsync()
        {
            try
            {
                return
                    await _db.ExperienceWorks
                             .Where(x => x.DisabledAt == null)
                             .CountAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar quantidade de itens na tabela de experiências profissionais", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar quantidade de itens na tabela de experiências profissionais", ex);
            }
        }

        public async Task<ListAllEntityVO<ExperienceWork>> GetAllAsync(int? limit = null, int? page = null, int? userId = null)
        {
            try
            {
                int portfolioId =
                    userId.HasValue ?
                    await _userRepo.GetIdPortfolioSelectedCurrentAsync(userId.Value) :
                    -1;

                ListAllEntityVO<ExperienceWork> response = new ListAllEntityVO<ExperienceWork>();
                response.TotalItems = await CountAsync();

                if (response.TotalItems <= 0)
                    return response;

                StaticMethods.GetPaginationItems(ref response, ref limit, ref page);

                response.Items =
                    await _db.ExperienceWorks
                             .Where(x => x.DisabledAt == null &&
                                         (userId == null || x.PortfolioId == portfolioId))
                             .Include(x => x.JourneyWorkStatus)
                             .Include(x => x.Portfolio)
                             .OrderByDescending(x => x.StartDate)
                             .ThenBy(x => x.OfficeName)
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
                _logService.Write($"Falha inesperada ao listar experiências profissionais da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar experiências profissionais da base de dados", ex);
            }
        }

        public async Task<List<ExperienceWork>> GetAllByPortfolioIdAsync(int portfolioId)
        {
            try
            {
                return
                    await _db.ExperienceWorks
                             .Where(x => x.DisabledAt == null &&
                                         x.PortfolioId == portfolioId)
                             .Include(x => x.JourneyWorkStatus)
                             .Include(x => x.Portfolio)
                             .OrderByDescending(x => x.StartDate)
                             .ThenBy(x => x.OfficeName)
                             .ToListAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar experiências profissionais pelo id de portoflio {portfolioId}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar experiências profissionais pelo portfolio informado", ex);
            }
        }

        public async Task<ExperienceWork> GetByIdAsync(int id)
        {
            try
            {
                return
                    await _db.ExperienceWorks
                             .Where(x => x.DisabledAt == null &&
                                         x.Id == id)
                             .Include(x => x.JourneyWorkStatus)
                             .Include(x => x.Portfolio)
                             .FirstOrDefaultAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar experiências profissionais pelo id {id}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar experiências profissionais pelo id {id}", ex);
            }
        }

        public async Task<ExperienceWork> InsertAsync(ExperienceWork model)
        {
            try
            {
                model.Id = 0;

                _db.ExperienceWorks.Add(model);
                await _db.SaveChangesAsync();

                return await GetByIdAsync(model.Id);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao inserir experiências profissionais na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao inserir experiências profissionais na base de dados", ex);
            }
        }

        public async Task<ExperienceWork> RemoveAsync(int id)
        {
            try
            {
                ExperienceWork save = await GetByIdAsync(id);
                if (save == null)
                    throw new RepositoryException($"Não foi encontrado uma experiência profissional com o id {id}");

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
                _logService.Write($"Falha inesperada ao deletar experiências profissional pelo id {id}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao deletar experiências profissional pelo id {id}", ex);
            }
        }

        public async Task<ExperienceWork> UpdateAsync(ExperienceWork model)
        {
            try
            {
                ExperienceWork? save =
                    await _db.ExperienceWorks
                             .Where(x => x.DisabledAt == null &&
                                         x.Id == model.Id)
                             .FirstOrDefaultAsync();

                if (save == null)
                    throw new RepositoryException($"Não foi encontrado uma experiência profissional com o id {model.Id}");

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
                _logService.Write($"Falha inesperada ao editar experiências profissionais na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao editar experiências profissionais na base de dados", ex);
            }
        }
    }
}
