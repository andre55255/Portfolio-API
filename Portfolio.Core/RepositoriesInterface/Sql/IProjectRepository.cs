using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IProjectRepository
    {
        public Task<Project> InsertAsync(Project model);
        public Task<Project> UpdateAsync(Project model);
        public Task<Project> RemoveAsync(int id);
        public Task<Project> GetByIdAsync(int id);
        public Task<ListAllEntityVO<Project>> GetAllAsync(int? limit = null, int? page = null);
        public Task<int> CountAsync();
        public Task<List<Project>> GetAllByPortfolioIdAsync(int portfolioId);
    }
}
