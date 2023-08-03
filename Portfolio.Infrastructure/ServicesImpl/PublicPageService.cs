using Microsoft.AspNetCore.Http;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ContactMe;
using Portfolio.Communication.ViewObjects.ExperienceEducation;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Project;
using Portfolio.Communication.ViewObjects.Stacks;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class PublicPageService : IPublicPageService
    {
        private readonly ILogService _logService;
        private readonly IPortfolioConfigService _portfolioService;
        private readonly IProjectService _projectService;
        private readonly IExperienceWorkService _experienceWorkService;
        private readonly IContactMeService _contactMeService;
        private readonly IExperienceEducationService _experienceEducationService;
        private readonly IStackService _stackService;

        public PublicPageService(ILogService logService, IPortfolioConfigService portfolioService, IExperienceWorkService experienceWorkService, IExperienceEducationService experienceEducationService, IContactMeService contactMeService, IProjectService projectService, IStackService stackService)
        {
            _logService = logService;
            _portfolioService = portfolioService;
            _experienceWorkService = experienceWorkService;
            _experienceEducationService = experienceEducationService;
            _contactMeService = contactMeService;
            _projectService = projectService;
            _stackService = stackService;
        }

        public async Task<List<ExperienceEducationReturnVO>> GetMyExperiencesEducationAsync(PublicPageRequestDataVO requestData)
        {
            try
            {
                return
                    await _experienceEducationService.GetExperiencesEducationByKeyAcessPortfolioAsync(requestData.KeyAccess);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar dados de minhas experiências educacionais pela key {requestData.KeyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao pegar dados de minhas experiências educacionais", ex);
            }
        }

        public async Task<List<ExperienceWorkReturnVO>> GetMyExperiencesWorkAsync(PublicPageRequestDataVO requestData)
        {
            try
            {
                return
                    await _experienceWorkService.GetExperiencesWorkdsByKeyAcessPortfolioAsync(requestData.KeyAccess);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar dados de minhas experiências profissionais pela key {requestData.KeyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao pegar dados de minhas experiências profissionais", ex);
            }
        }

        public async Task<PortfolioReturnVO> GetPortfolioAsync(PublicPageRequestDataVO requestData)
        {
            try
            {
                return
                    await _portfolioService.GetByKeyAccessAsync(requestData.KeyAccess);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar dados de portfolio pela key {requestData.KeyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao pegar dados de portfolio", ex);
            }
        }

        public async Task<List<ProjectReturnVO>> GetProjectsAsync(PublicPageRequestDataVO requestData)
        {
            try
            {
                return
                    await _projectService.GetProjectsByKeyAcessPortfolioAsync(requestData.KeyAccess);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar dados de projetos pela key {requestData.KeyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao pegar dados de projetos", ex);
            }
        }

        public PublicPageRequestDataVO GetRequestData(HttpRequest request)
        {
            try
            {
                string keyAccess =
                    request.Headers
                           .Where(x => x.Key.ToUpper() == "Key-Portfolio".ToUpper())
                           .Select(x => x.Value)
                           .FirstOrDefault();

                if (keyAccess == null)
                    throw new ValidException($"Não foi informada uma key de portfolio, verifique");

                return new PublicPageRequestDataVO
                {
                    KeyAccess = keyAccess
                };
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar dados de credenciais da requisição", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao pegar dados de credenciais da requisição", ex);
            }
        }

        public async Task<List<StackReturnVO>> GetStacksAsync(PublicPageRequestDataVO requestData)
        {
            try
            {
                return
                    await _stackService.GetStacksByKeyAcessPortfolioAsync(requestData.KeyAccess);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao pegar dados de minhas stacks pela key {requestData.KeyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao pegar dados de minhas stacks", ex);
            }
        }

        public async Task<ContactMeReturnVO> SaveContactMeAsync(SaveContactMeVO contactMe, PublicPageRequestDataVO requestData)
        {
            try
            {
                return
                    await _contactMeService.InsertAsync(contactMe, requestData);
            }
            catch (ConflictException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao salvar contato para o portfolio de key {requestData.KeyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao salvar contato", ex);
            }
        }
    }
}
