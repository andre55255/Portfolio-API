using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IContactMeRepository
    {
        public Task<ContactMe> InsertAsync(ContactMe model);
        public Task<ContactMe> UpdateAsync(ContactMe model);
        public Task<ContactMe> RemoveAsync(int id);
        public Task<ContactMe> GetByIdAsync(int id);
        public Task<ListAllEntityVO<ContactMe>> GetAllAsync(int? limit = null, int? page = null);
        public Task<int> CountAsync();
        public Task<List<ContactMe>> GetAllByPortfolioIdAsync(int portfolioId);
    }
}
