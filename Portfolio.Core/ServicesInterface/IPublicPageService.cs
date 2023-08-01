using Microsoft.AspNetCore.Http;
using Portfolio.Communication.ViewObjects.ExperienceEducation;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IPublicPageService
    {
        public Task<List<ExperienceEducationReturnVO>> GetMyExperiencesEducationAsync(PublicPageRequestDataVO requestData);
        public Task<List<ExperienceWorkReturnVO>> GetMyExperiencesWorkAsync(PublicPageRequestDataVO requestData);
        public Task<PortfolioReturnVO> GetPortfolioAsync(PublicPageRequestDataVO requestData);
        public PublicPageRequestDataVO GetRequestData(HttpRequest request);
    }
}
