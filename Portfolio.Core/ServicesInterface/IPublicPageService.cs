using Microsoft.AspNetCore.Http;
using Portfolio.Communication.ViewObjects.ContactMe;
using Portfolio.Communication.ViewObjects.ExperienceEducation;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Project;
using Portfolio.Communication.ViewObjects.Stacks;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IPublicPageService
    {
        public Task<List<ExperienceEducationReturnVO>> GetMyExperiencesEducationAsync(PublicPageRequestDataVO requestData);
        public Task<List<ExperienceWorkReturnVO>> GetMyExperiencesWorkAsync(PublicPageRequestDataVO requestData);
        public Task<PortfolioReturnVO> GetPortfolioAsync(PublicPageRequestDataVO requestData);
        public Task<List<ProjectReturnVO>> GetProjectsAsync(PublicPageRequestDataVO requestData);
        public PublicPageRequestDataVO GetRequestData(HttpRequest request);
        public Task<List<StackReturnVO>> GetStacksAsync(PublicPageRequestDataVO requestData);
        public Task<ContactMeReturnVO> SaveContactMeAsync(SaveContactMeVO contactMe, PublicPageRequestDataVO requestData);
    }
}
