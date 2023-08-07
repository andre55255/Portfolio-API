using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioConfigService _portfolioService;
        private readonly IApiInfoService _apiInfoService;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public PortfolioController(IPortfolioConfigService portfolioService, IMapper mapper, ILogService logService, IApiInfoService apiInfoService)
        {
            _portfolioService = portfolioService;
            _mapper = mapper;
            _logService = logService;
            _apiInfoService = apiInfoService;
        }

        /// <summary>
        /// POST - Método para criar um portfolio na base de dados, passar dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SavePortfolioVO model)
        {
            try
            {
                PortfolioReturnVO result = await _portfolioService.InsertAsync(model, model.UsersIds);

                return StatusCode(StatusCodes.Status201Created,
                    APIResponseVO.Ok($"Portfolio criado com sucesso",
                        result));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha no método de criação de portfolio", this.GetPlace(), ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de criação de portfolio"));
            }
        }

        /// <summary>
        /// PUT {id} - Método para editar uma configuração na base de dados, passar id pela url e dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync([Required(ErrorMessage = "Id não informado")] int id, [FromBody] SavePortfolioVO model)
        {
            try
            {
                PortfolioReturnVO result = await _portfolioService.UpdateAsync(id, model, model.UsersIds);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Portfolio editado com sucesso",
                        result));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha no método de edição de portfolio", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de edição de portfolio"));
            }
        }

        /// <summary>
        /// DELETE {id} - Método para deletar uma configuração por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync([Required(ErrorMessage = "Id não informado")] int id)
        {
            try
            {
                PortfolioReturnVO result = await _portfolioService.RemoveAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Portfolio deletado com sucesso",
                        result));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha no método de deleção de portfolio", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de deleção de portfolio"));
            }

        }

        /// <summary>
        /// GET - Método para listar configurações na base de dados, dados opcionais para paginação. Passar pela query ?limit=int page=int
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int? limit = null, int? page = null)
        {
            try
            {
                RequestDataVO requestData = _apiInfoService.GetRequestData(Request);

                ListAllEntityVO<PortfolioReturnVO> list = await _portfolioService.GetAllAsync(limit, page, requestData);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Portfolios listados com scuesso", list));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar portfolios", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar portfolios"));
            }
        }

        /// <summary>
        /// GET {id} - Método para listar uma configuração por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([Required(ErrorMessage = "Id não informado")] int id)
        {
            try
            {
                PortfolioReturnVO type = await _portfolioService.GetByIdAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                     APIResponseVO.Ok($"Portfolio listado com sucesso", type));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar portfolio, id: {id}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar portfolio, id: {id}"));
            }
        }

        /// <summary>
        /// GetPortfoliosToSelect - Método para listar portfolios para seleção da base de dados. Sem parâmetros
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("GetPortfoliosToSelect")]
        public async Task<IActionResult> GetPortfoliosToSelectAsync()
        {
            try
            {
                RequestDataVO requestData = _apiInfoService.GetRequestData(Request);

                List<SelectObjectVO> list = await _portfolioService.GetPortfoliosToSelectObjectAsync(requestData);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Portfolios para seleção listados com scuesso", list));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar portfolios para seleção ", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar portfolios para seleção "));
            }
        }
    }
}
