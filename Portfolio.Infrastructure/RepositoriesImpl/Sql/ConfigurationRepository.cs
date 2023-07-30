using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;
using Portfolio.Core.RepositoriesInterface.Sql;

namespace Portfolio.Infrastructure.RepositoriesImpl.Sql
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ListAllEntityVO<Configuration>> GetAllAsync(int? limit = null, int? page = null)
        {
            throw new NotImplementedException();
        }

        public Task<Configuration> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Configuration> GetByTokenAsync(string token)
        {
            throw new NotImplementedException();
        }

        public Task<Configuration> InsertAsync(Configuration model)
        {
            throw new NotImplementedException();
        }

        public Task<Configuration> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Configuration> UpdateAsync(Configuration model)
        {
            throw new NotImplementedException();
        }
    }
}
