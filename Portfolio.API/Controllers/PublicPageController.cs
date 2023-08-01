using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ContactMe;
using Portfolio.Communication.ViewObjects.ExperienceEducation;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using System.Text.Json;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicPageController : ControllerBase
    {
        private readonly IPublicPageService _publicPageService;
        private readonly ILogService _logService;

        public PublicPageController(IPublicPageService publicPageService, ILogService logService)
        {
            _publicPageService = publicPageService;
            _logService = logService;
        }

        /// <summary>
        /// GetPortoflio - Método para listar dados de portfolio baseado na key informada pelo header, keyPortFolio=abs1235
        /// </summary>
        [HttpGet]
        [Route("GetPortfolio")]
        public async Task<IActionResult> GetPortolioAsync()
        {
            try
            {
                PublicPageRequestDataVO requestData = _publicPageService.GetRequestData(Request);

                PortfolioReturnVO portfolio =
                    await _publicPageService.GetPortfolioAsync(requestData);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Portfolio listado com sucesso", portfolio));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (AuthencationAppException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao fazer rotina de pegar dados de portfolio. Headers: {JsonSerializer.Serialize(Request.Headers)}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail(ex.Message));
            }
        }

        /// <summary>
        /// GetMyExperiencesWork - Método para listar dados de minhas experiências profissionais baseado na key informada pelo header, keyPortFolio=abs1235
        /// </summary>
        [HttpGet]
        [Route("GetMyExperiencesWork")]
        public async Task<IActionResult> GetMyExperiencesWorkAsync()
        {
            try
            {
                PublicPageRequestDataVO requestData = _publicPageService.GetRequestData(Request);

                List<ExperienceWorkReturnVO> data =
                    await _publicPageService.GetMyExperiencesWorkAsync(requestData);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Minhas experiências profissionais listadas com sucesso", data));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (AuthencationAppException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao fazer rotina de pegar dados de minhas experiências profissionais. Headers: {JsonSerializer.Serialize(Request.Headers)}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao fazer rotina de pegar dados de minhas experiências profissionais"));
            }
        }

        /// <summary>
        /// GetMyExperiencesEducation - Método para listar dados de minhas experiências educacionais baseado na key informada pelo header, keyPortFolio=abs1235
        /// </summary>
        [HttpGet]
        [Route("GetMyExperiencesEducation")]
        public async Task<IActionResult> GetMyExperiencesEducationAsync()
        {
            try
            {
                PublicPageRequestDataVO requestData = _publicPageService.GetRequestData(Request);

                List<ExperienceEducationReturnVO> data =
                    await _publicPageService.GetMyExperiencesEducationAsync(requestData);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Minhas experiências educacionais listadas com sucesso", data));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (AuthencationAppException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao fazer rotina de pegar dados de minhas experiências educacionais. Headers: {JsonSerializer.Serialize(Request.Headers)}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao fazer rotina de pegar dados de minhas experiências educacionais"));
            }
        }

        [HttpPost]
        [Route("SaveContactMe")]
        public async Task<IActionResult> SaveContactMeAsync([FromBody] SaveContactMeVO contactMe)
        {
            try
            {
                PublicPageRequestDataVO requestData = _publicPageService.GetRequestData(Request);

                ContactMeReturnVO data =
                    await _publicPageService.SaveContactMeAsync(contactMe, requestData);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Contato salvo com sucesso", data));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (AuthencationAppException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao fazer rotina de salvar contato. Data: {JsonSerializer.Serialize(contactMe)}. Headers: {JsonSerializer.Serialize(Request.Headers)}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao fazer rotina de salvar contato"));
            }
        }
    }
}
