using Portfolio.Communication.ViewObjects.ContactMe;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IContactMeService
    {
        public Task<ContactMeReturnVO> InsertAsync(SaveContactMeVO model, PublicPageRequestDataVO publicPageRequestData = null, RequestDataVO requestData = null);
        public Task<ContactMeReturnVO> UpdateAsync(int? id, SaveContactMeVO model, PublicPageRequestDataVO publicPageRequestData = null, RequestDataVO requestData = null);
        public Task<ContactMeReturnVO> RemoveAsync(int? id);
        public Task<ContactMeReturnVO> GetByIdAsync(int? id);
        public Task<ListAllEntityVO<ContactMeReturnVO>> GetAllAsync(int? limit = null, int? page = null);
        public Task<List<ContactMeReturnVO>> GetAllByPortfolioIdAsync(int? portfolioId, RequestDataVO requestData);
    }
}
