using Microsoft.AspNetCore.Http;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class PublicPageService : IPublicPageService
    {
        private readonly ILogService _logService;
        private readonly IPortfolioConfigService _portfolioService;
        private readonly IExperienceWorkService _experienceWorkService;

        public PublicPageService(ILogService logService, IPortfolioConfigService portfolioService, IExperienceWorkService experienceWorkService)
        {
            _logService = logService;
            _portfolioService = portfolioService;
            _experienceWorkService = experienceWorkService;
        }

        public async Task<List<ExperienceWorkReturnVO>> GetMyExperiencesAsync(PublicPageRequestDataVO requestData)
        {
            try
            {
                return
                    await _experienceWorkService.GetExperiencesWorkdsByKeyAcessPortfolioAsync(requestData.KeyAccess)
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
                _logService.Write($"Falha inesperada ao pegar dados de minhas experiências pela key {requestData.KeyAccess}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao pegar dados de minhas experiências", ex);
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

        public PublicPageRequestDataVO GetRequestData(HttpRequest request)
        {
            try
            {
                string keyAccess =
                    request.Headers
                           .Where(x => x.Key == "keyPortFolio")
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
    }
}
