using Microsoft.AspNetCore.Http;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IPublicPageService
    {
        public Task<List<ExperienceWorkReturnVO>> GetMyExperiencesAsync(PublicPageRequestDataVO requestData);
        public Task<PortfolioReturnVO> GetPortfolioAsync(PublicPageRequestDataVO requestData);
        public PublicPageRequestDataVO GetRequestData(HttpRequest request);
    }
}
