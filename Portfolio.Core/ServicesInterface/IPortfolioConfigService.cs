using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IPortfolioConfigService
    {
        public Task<PortfolioReturnVO> InsertAsync(SavePortfolioVO model, List<int> usersIdsAsociates);
        public Task<PortfolioReturnVO> UpdateAsync(int id, SavePortfolioVO model, List<int> usersIdsAsociates);
        public Task<PortfolioReturnVO> RemoveAsync(int id);
        public Task<PortfolioReturnVO> GetByIdAsync(int id);
        public Task<PortfolioReturnVO> GetByKeyAccessAsync(string keyAccess);
        public Task<ListAllEntityVO<PortfolioReturnVO>> GetAllAsync(int? limit = null, int? page = null);
        public Task<ListAllEntityVO<PortfolioReturnVO>> GetAllAsync(int? limit, int? page, RequestDataVO requestData);
        public Task ValidPermissionAccessAsync(int portfolioId, int userId);
    }
}
