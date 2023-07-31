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
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly SqlDbContext _db;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public ConfigurationRepository(SqlDbContext db, ILogService logService, IMapper mapper)
        {
            _db = db;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<int> CountAsync()
        {
            try
            {
                int count =
                    await _db.Configurations
                             .Where(x => x.DisabledAt == null)
                             .CountAsync();

                return count;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao pegar quantidade de itens na tabela de configurações", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao pegar quantidade de itens na tabela de configurações", ex);
            }
        }

        public async Task<ListAllEntityVO<Configuration>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<Configuration> response = new ListAllEntityVO<Configuration>();
                response.TotalItems = await CountAsync();

                if (response.TotalItems.Value <= 0)
                    return response;

                StaticMethods.GetPaginationItems(ref response, ref limit, ref page);

                response.Items =
                    await _db.Configurations
                             .Where(x => x.DisabledAt == null)
                             .OrderBy(x => x.Token)
                             .ThenBy(x => x.Value)
                             .Skip(limit.Value * page.Value)
                             .Take(limit.Value)
                             .AsNoTracking()
                             .ToListAsync();

                return response;
            }
            catch (ValidException ex)
            {
                throw new RepositoryException(ex.Message, ex);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar configurações da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao listar configurações da base de dados", ex);
            }
        }

        public async Task<Configuration> GetByIdAsync(int id)
        {
            try
            {
                Configuration? item =
                    await _db.Configurations
                             .Where(x => x.DisabledAt == null &&
                                         x.Id == id)
                             .FirstOrDefaultAsync();

                return item;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao buscar configuração por id: {id}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao buscar configuração por id: {id}", ex);
            }
        }

        public async Task<Configuration> GetByTokenAsync(string token)
        {
            try
            {
                Configuration? response =
                    await _db.Configurations
                             .Where(x => x.DisabledAt == null &&
                                         x.Token == token)
                             .AsNoTracking()
                             .FirstOrDefaultAsync();

                return response;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao buscar configuração por token: {token}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao buscar configuração por token: {token}", ex);
            }
        }

        public async Task<Configuration> InsertAsync(Configuration model)
        {
            try
            {
                model.Id = 0;

                _db.Configurations.Add(model);
                await _db.SaveChangesAsync();

                return model;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao inserir configuração na base de dados: {model.Token} - {model.Value}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao inserir configuração na base de dados: {model.Token} - {model.Value}", ex);
            }
        }

        public async Task<Configuration> RemoveAsync(int id)
        {
            try
            {
                Configuration model = await GetByIdAsync(id);

                model.DisabledAt = DateTime.Now;
                await _db.SaveChangesAsync();

                return model;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao remover configuração na base de dados: {id}", this.GetPlace(), ex);
                throw new RepositoryException("Falha ao remover configuração na base de dados", ex);
            }
        }

        public async Task<Configuration> UpdateAsync(Configuration model)
        {
            try
            {
                Configuration save = await GetByIdAsync(model.Id);

                model.CreatedAt = save.CreatedAt;
                model.UpdatedAt = DateTime.Now;

                _mapper.Map(model, save);
                await _db.SaveChangesAsync();

                return save;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao editar configuração na base de dados: {model.Id}", this.GetPlace(), ex);
                throw new RepositoryException("Falha ao editar configuração na base de dados", ex);
            }
        }
    }
}
