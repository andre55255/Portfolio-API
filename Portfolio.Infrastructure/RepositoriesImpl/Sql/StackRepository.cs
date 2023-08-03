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
    public class StackRepository : IStackRepository
    {
        private readonly SqlDbContext _db;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public StackRepository(SqlDbContext db, ILogService logService, IMapper mapper)
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
                    await _db.Stacks
                             .Where(x => x.DisabledAt == null)
                             .CountAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar quantidade de itens na tabela de stacks", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar quantidade de itens na tabela de stacks", ex);
            }
        }

        public async Task<ListAllEntityVO<Stack>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<Stack> response = new ListAllEntityVO<Stack>();
                response.TotalItems = await CountAsync();

                if (response.TotalItems <= 0)
                    return response;

                StaticMethods.GetPaginationItems(ref response, ref limit, ref page);

                response.Items =
                    await _db.Stacks
                             .Where(x => x.DisabledAt == null)
                             .Include(x => x.Portfolio)
                             .OrderBy(x => x.Name)
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
                _logService.Write($"Falha inesperada ao listar stacks da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar stacks da base de dados", ex);
            }
        }

        public async Task<List<Stack>> GetAllByPortfolioIdAsync(int portfolioId)
        {
            try
            {
                return
                    await _db.Stacks
                             .Where(x => x.DisabledAt == null &&
                                         x.PortfolioId == portfolioId)
                             .Include(x => x.Portfolio)
                             .OrderBy(x => x.Name)
                             .AsNoTracking()
                             .ToListAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar stacks do portfolio {portfolioId} da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar stacks do portfolio {portfolioId} tda base de dados", ex);
            }
        }

        public async Task<Stack> GetByIdAsync(int id)
        {
            try
            {
                return
                    await _db.Stacks
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
                _logService.Write($"Falha inesperada ao listar stack pelo id {id} da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar stack pelo id {id} tda base de dados", ex);
            }
        }

        public async Task<Stack> InsertAsync(Stack model)
        {
            try
            {
                model.Id = 0;

                _db.Stacks.Add(model);
                await _db.SaveChangesAsync();

                return await GetByIdAsync(model.Id);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao inserir stack {model.Name} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao inserir stack {model.Name} na base de dados", ex);
            }
        }

        public async Task<Stack> RemoveAsync(int id)
        {
            try
            {
                Stack save = await GetByIdAsync(id);
                if (save == null)
                    throw new RepositoryException($"Não foi encontrado uma stack com o id {id}");

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
                _logService.Write($"Falha inesperada ao remover stack {id} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao remover stack {id} na base de dados", ex);
            }
        }

        public async Task<Stack> UpdateAsync(Stack model)
        {
            try
            {
                Stack? save =
                    await _db.Stacks
                             .Where(x => x.Id == model.Id &&
                                         x.DisabledAt == null)
                             .FirstOrDefaultAsync();

                if (save == null)
                    throw new RepositoryException($"Não foi encontrado uma stack com o id {model.Id}");

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
                _logService.Write($"Falha inesperada ao editar stack {model.Id} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao editar stack {model.Id} na base de dados", ex);
            }
        }
    }
}
