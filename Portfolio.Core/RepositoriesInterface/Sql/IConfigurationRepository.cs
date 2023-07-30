using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IConfigurationRepository
    {
        public Task<Configuration> InsertAsync(Configuration model);
        public Task<Configuration> UpdateAsync(Configuration model);
        public Task<Configuration> RemoveAsync(int id);
        public Task<Configuration> GetByIdAsync(int id);
        public Task<Configuration> GetByTokenAsync(string token);
        public Task<ListAllEntityVO<Configuration>> GetAllAsync(int? limit = null, int? page = null);
        public Task<int> CountAsync();
    }
}
