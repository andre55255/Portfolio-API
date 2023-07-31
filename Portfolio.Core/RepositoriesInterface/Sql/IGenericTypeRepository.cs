using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IGenericTypeRepository
    {
        public Task<GenericType> InsertAsync(GenericType model);
        public Task<GenericType> UpdateAsync(GenericType model);
        public Task<GenericType> RemoveAsync(int id);
        public Task<GenericType> GetByIdAsync(int id);
        public Task<List<GenericType>> GetByTokenAsync(string token);
        public Task<ListAllEntityVO<GenericType>> GetAllAsync(int? limit = null, int? page = null);
        public Task<int> CountAsync();
    }
}
