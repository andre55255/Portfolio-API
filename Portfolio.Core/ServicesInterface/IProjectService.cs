using Portfolio.Communication.ViewObjects.Project;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IProjectService
    {
        public Task<ProjectReturnVO> InsertAsync(SaveProjectVO model, RequestDataVO request);
        public Task<ProjectReturnVO> UpdateAsync(int? id, SaveProjectVO model, RequestDataVO request);
        public Task<ProjectReturnVO> RemoveAsync(int? id);
        public Task<ProjectReturnVO> GetByIdAsync(int? id);
        public Task<ListAllEntityVO<ProjectReturnVO>> GetAllAsync(int? limit = null, int? page = null);
        public Task<List<ProjectReturnVO>> GetProjectsByKeyAcessPortfolioAsync(string keyAccess);
    }
}

