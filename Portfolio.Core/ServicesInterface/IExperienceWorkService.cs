using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IExperienceWorkService
    {
        public Task<ExperienceWorkReturnVO> InsertAsync(SaveExperienceWorkVO model, RequestDataVO request);
        public Task<ExperienceWorkReturnVO> UpdateAsync(int? id, SaveExperienceWorkVO model, RequestDataVO request);
        public Task<ExperienceWorkReturnVO> RemoveAsync(int? id);
        public Task<ExperienceWorkReturnVO> GetByIdAsync(int? id);
        public Task<ListAllEntityVO<ExperienceWorkReturnVO>> GetAllAsync(int? limit = null, int? page = null);
        public Task<List<ExperienceWorkReturnVO>> GetExperiencesWorkdsByKeyAcessPortfolioAsync(string keyAccess);
    }
}
