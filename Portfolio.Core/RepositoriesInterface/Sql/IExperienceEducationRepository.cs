using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IExperienceEducationRepository
    {
        public Task<ExperienceEducation> InsertAsync(ExperienceEducation model);
        public Task<ExperienceEducation> UpdateAsync(ExperienceEducation model);
        public Task<ExperienceEducation> RemoveAsync(int id);
        public Task<ExperienceEducation> GetByIdAsync(int id);
        public Task<ListAllEntityVO<ExperienceEducation>> GetAllAsync(int? limit = null, int? page = null);
        public Task<List<ExperienceEducation>> GetAllByPortfolioIdAsync(int portfolioId);
        public Task<int> CountAsync();
    }
}
