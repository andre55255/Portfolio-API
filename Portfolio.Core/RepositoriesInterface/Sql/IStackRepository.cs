using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IStackRepository
    {
        public Task<Stack> InsertAsync(Stack model);
        public Task<Stack> UpdateAsync(Stack model);
        public Task<Stack> RemoveAsync(int id);
        public Task<Stack> GetByIdAsync(int id);
        public Task<ListAllEntityVO<Stack>> GetAllAsync(int? limit = null, int? page = null, int? userId = null);
        public Task<int> CountAsync();
        public Task<List<Stack>> GetAllByPortfolioIdAsync(int portfolioId);
    }
}
