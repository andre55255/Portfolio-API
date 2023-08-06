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
    public class PortfolioConfigRepository : IPortfolioConfigRepository
    {
        private readonly SqlDbContext _db;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public PortfolioConfigRepository(SqlDbContext db, ILogService logService, IMapper mapper)
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
                    await _db.Portfolios
                             .Where(x => x.DisabledAt == null)
                             .CountAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar quantidade de itens na tabela de portfolios", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar quantidade de itens na tabela de portfolios", ex);
            }
        }

        public async Task<bool> IsPermissionAccessByUserIdAsync(int portfolioId, int userId)
        {
            try
            {
                return
                    await _db.PortofolioUsersAssociates
                             .Where(x => x.UserId == userId &&
                                         x.PortfolioId == portfolioId)
                             .AnyAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao verificar se o usuário {userId} tem permissão no portfolio {portfolioId}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao verificar se o usuário {userId} tem permissão no portfolio {portfolioId}", ex);
            }
        }

        public async Task<bool> IsExistByIdAsync(int portfolioId)
        {
            try
            {
                return
                    await _db.Portfolios
                             .Where(x => x.DisabledAt == null &&
                                         x.Id == portfolioId)
                             .AnyAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao verificar se portfolio existe com o id {portfolioId}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao verificar se portfolio existe com o id {portfolioId}", ex);
            }
        }

        public async Task<bool> IsExistByKeyAccessAsync(string keyAccess)
        {
            try
            {
                return
                    await _db.Portfolios
                             .Where(x => x.DisabledAt == null &&
                                         x.KeyAccess == keyAccess)
                             .AnyAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao verificar se portfolio existe com a key {keyAccess}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao verificar se portfolio existe com a key informada", ex);
            }
        }

        public async Task<int?> GetIdByKeyAccessAsync(string keyAccess)
        {
            try
            {
                return
                    await _db.Portfolios
                             .Where(x => x.DisabledAt == null &&
                                         x.KeyAccess == keyAccess)
                             .Select(x => x.Id)
                             .FirstOrDefaultAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar identificador de portfolio com a key {keyAccess}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao pegar identificador de portfolio com a key informada", ex);
            }
        }

        public async Task<ListAllEntityVO<PortfolioConfig>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<PortfolioConfig> response = new ListAllEntityVO<PortfolioConfig>();
                response.TotalItems = await CountAsync();

                if (response.TotalItems <= 0)
                    return response;

                StaticMethods.GetPaginationItems(ref response, ref limit, ref page);

                response.Items =
                    await _db.Portfolios
                             .Where(x => x.DisabledAt == null)
                             .Include(x => x.UsersAssociates)
                             .OrderBy(x => x.Title)
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
                _logService.Write($"Falha inesperada ao listar portfolios da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar portfolios da base de dados", ex);
            }
        }

        public async Task<PortfolioConfig> GetByIdAsync(int id)
        {
            try
            {
                return
                    await _db.Portfolios
                             .Where(x => x.DisabledAt == null &&
                                         x.Id == id)
                             .Include(x => x.UsersAssociates)
                             .FirstOrDefaultAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar portolio pelo id {id}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar portolio pelo id {id}", ex);
            }
        }

        public async Task<PortfolioConfig> GetByKeyAccessAsync(string keyAccess)
        {
            try
            {
                return
                    await _db.Portfolios
                             .Where(x => x.DisabledAt == null &&
                                         x.KeyAccess == keyAccess)
                             .Include(x => x.UsersAssociates)
                             .FirstOrDefaultAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar portolio pelo key {keyAccess}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar portolio pelo key", ex);
            }
        }

        public async Task<PortfolioConfig> InsertAsync(PortfolioConfig model, List<int> usersIdsAsociates)
        {
            try
            {
                model.Id = 0;

                _db.Portfolios.Add(model);
                await _db.SaveChangesAsync();

                await AssociatePortfolioWithUserAsync(model, usersIdsAsociates);
                return await GetByIdAsync(model.Id);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao inserir portfolio na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao inserir portfolio na base de dados", ex);
            }
        }

        public async Task<PortfolioConfig> RemoveAsync(int id)
        {
            try
            {
                PortfolioConfig save = await GetByIdAsync(id);
                if (save == null)
                    throw new RepositoryException($"Não foi encontrado um porfolio com o id {id} para deleção");

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
                _logService.Write($"Falha inesperada ao deletar portfolio pelo id {id} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao deletar portfolio pelo id {id} na base de dados", ex);
            }
        }

        public async Task<PortfolioConfig> UpdateAsync(PortfolioConfig model, List<int> usersIdsAsociates)
        {
            try
            {
                PortfolioConfig save = await GetByIdAsync(model.Id);
                if (save == null)
                    throw new RepositoryException($"Não foi encontrado um porfolio com o id {model.Id} para deleção");

                model.CreatedAt = save.CreatedAt;
                model.UpdatedAt = DateTime.Now;

                _mapper.Map(model, save);
                await _db.SaveChangesAsync();

                await AssociatePortfolioWithUserAsync(save, usersIdsAsociates);
                return await GetByIdAsync(model.Id);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao editar portfolio pelo id {model.Id} na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao editar portfolio pelo id {model.Id} na base de dados", ex);
            }
        }

        private async Task AssociatePortfolioWithUserAsync(PortfolioConfig model, List<int> usersIdsAsociates)
        {
            try
            {
                List<PortfolioConfigUsersAssociate> associates =
                    await _db.PortofolioUsersAssociates
                             .Where(x => x.PortfolioId == model.Id)
                             .ToListAsync();

                _db.PortofolioUsersAssociates.RemoveRange(associates);

                List<PortfolioConfigUsersAssociate> inserts = new List<PortfolioConfigUsersAssociate>();
                foreach (int userId in usersIdsAsociates)
                {
                    inserts.Add(new PortfolioConfigUsersAssociate
                    {
                        PortfolioId = model.Id,
                        UserId = userId,
                    });
                }

                _db.PortofolioUsersAssociates.AddRange(inserts);
                await _db.SaveChangesAsync();
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao inserir portfolio na base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao inserir portfolio na base de dados", ex);
            }
        }

        public async Task<ListAllEntityVO<PortfolioConfig>> GetAllAsync(int? limit, int? page, int userId)
        {
            try
            {
                ListAllEntityVO<PortfolioConfig> response = new ListAllEntityVO<PortfolioConfig>();
                response.TotalItems = await CountAsync();

                if (response.TotalItems <= 0)
                    return response;

                StaticMethods.GetPaginationItems(ref response, ref limit, ref page);

                response.Items =
                    await _db.Portfolios
                             .Where(x => x.DisabledAt == null &&
                                         x.UsersAssociates
                                          .Where(x => x.Id == userId)
                                          .Any())
                             .Include(x => x.UsersAssociates)
                             .OrderBy(x => x.Title)
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
                _logService.Write($"Falha inesperada ao listar portfolios da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao listar portfolios da base de dados", ex);
            }
        }
    }
}
