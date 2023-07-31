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
    public class GenericTypeRepository : IGenericTypeRepository
    {
        private readonly SqlDbContext _db;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public GenericTypeRepository(SqlDbContext db, ILogService logService, IMapper mapper)
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
                    await _db.GenericTypes
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
                _logService.Write($"Falha ao pegar quantidade de itens na tabela de tipos genéricos", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao pegar quantidade de itens na tabela de tipos genéricos", ex);
            }
        }

        public async Task<ListAllEntityVO<GenericType>> GetAllAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<GenericType> response = new ListAllEntityVO<GenericType>();
                response.TotalItems = await CountAsync();

                if (response.TotalItems.Value <= 0)
                    return response;

                StaticMethods.GetPaginationItems(ref response, ref limit, ref page);

                response.Items =
                    await _db.GenericTypes
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
                _logService.Write($"Falha ao listar tipos genéricos da base de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao listar tipos genéricos da base de dados", ex);
            }
        }

        public async Task<GenericType> GetByIdAsync(int id)
        {
            try
            {
                GenericType? item =
                    await _db.GenericTypes
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
                _logService.Write($"Falha ao buscar tipo genérico por id: {id}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao buscar tipo genérico por id: {id}", ex);
            }
        }

        public async Task<List<GenericType>> GetByTokenAsync(string token)
        {
            try
            {
                List<GenericType> response =
                    await _db.GenericTypes
                             .Where(x => x.DisabledAt == null &&
                                         x.Token == token)
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
                _logService.Write($"Falha ao listar tipos genéricos por token: {token}", this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao listar tipos genéricos da base de dados", ex);
            }
        }

        public async Task<GenericType> InsertAsync(GenericType model)
        {
            try
            {
                model.Id = 0;

                _db.GenericTypes.Add(model);
                await _db.SaveChangesAsync();

                return model;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao inserir tipo genérico na base de dados: {model.Token} - {model.Value}",  this.GetPlace(), ex);
                throw new RepositoryException($"Falha ao inserir tipo genérico na base de dados: {model.Token} - {model.Value}", ex);
            }
        }

        public async Task<GenericType> RemoveAsync(int id)
        {
            try
            {
                GenericType model = await GetByIdAsync(id);

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
                _logService.Write($"Falha ao remover tipo genérico na base de dados: {id}", this.GetPlace(), ex);
                throw new RepositoryException("Falha ao remover tipo genérico na base de dados", ex);
            }
        }

        public async Task<GenericType> UpdateAsync(GenericType model)
        {
            try
            {
                GenericType save = await GetByIdAsync(model.Id);

                model.CreatedAt = save.CreatedAt;
                model.UpdatedAt = DateTime.Now;

                _mapper.Map(model, save);
                await _db.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao editar tipo genérico na base de dados: {model.Id}", this.GetPlace(), ex);
                throw new RepositoryException("Falha ao editar tipo genérico na base de dados", ex);
            }
        }
    }
}
