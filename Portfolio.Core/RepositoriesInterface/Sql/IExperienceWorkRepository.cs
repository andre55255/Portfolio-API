using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IExperienceWorkRepository
    {
        public Task<ExperienceWork> InsertAsync(ExperienceWork model);
        public Task<ExperienceWork> UpdateAsync(ExperienceWork model);
        public Task<ExperienceWork> RemoveAsync(int id);
        public Task<ExperienceWork> GetByIdAsync(int id);
        public Task<ListAllEntityVO<ExperienceWork>> GetAllAsync(int? limit = null, int? page = null, int? userId = null);
        public Task<int> CountAsync();
        public Task<List<ExperienceWork>> GetAllByPortfolioIdAsync(int portfolioId);
    }
}
