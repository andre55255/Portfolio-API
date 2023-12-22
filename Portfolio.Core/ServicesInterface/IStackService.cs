using Portfolio.Communication.ViewObjects.Stacks;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IStackService
    {
        public Task<StackReturnVO> InsertAsync(SaveStackVO model, RequestDataVO request);
        public Task<StackReturnVO> UpdateAsync(int? id, SaveStackVO model, RequestDataVO request);
        public Task<StackReturnVO> RemoveAsync(int? id);
        public Task<StackReturnVO> GetByIdAsync(int? id);
        public Task<ListAllEntityVO<StackReturnVO>> GetAllAsync(RequestDataVO requestData, int? limit = null, int? page = null);
        public Task<List<StackReturnVO>> GetStacksByKeyAcessPortfolioAsync(string keyAccess);
    }
}
