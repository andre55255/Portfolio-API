using Portfolio.Communication.ViewObjects.ExperienceEducation;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IExperienceEducationService
    {
        public Task<ExperienceEducationReturnVO> InsertAsync(SaveExperienceEducationVO model, RequestDataVO request);
        public Task<ExperienceEducationReturnVO> UpdateAsync(int? id, SaveExperienceEducationVO model, RequestDataVO request);
        public Task<ExperienceEducationReturnVO> RemoveAsync(int? id);
        public Task<ExperienceEducationReturnVO> GetByIdAsync(int? id);
        public Task<ListAllEntityVO<ExperienceEducationReturnVO>> GetAllAsync(int? limit = null, int? page = null);
        public Task<List<ExperienceEducationReturnVO>> GetExperiencesEducationByKeyAcessPortfolioAsync(string keyAccess);
    }
}
