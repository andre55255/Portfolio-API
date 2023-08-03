using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Stacks;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using System.Data;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StackController : ControllerBase
    {
        private readonly IApiInfoService _apiInfoService;
        private readonly IStackService _stackService;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public StackController(IApiInfoService apiInfoService, IStackService stackService, IMapper mapper, ILogService logService)
        {
            _apiInfoService = apiInfoService;
            _stackService = stackService;
            _mapper = mapper;
            _logService = logService;
        }

        /// <summary>
        /// POST - Método para criar uma stack na base de dados, passar dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SaveStackVO model)
        {
            try
            {
                RequestDataVO request = _apiInfoService.GetRequestData(Request);

                StackReturnVO result = await _stackService.InsertAsync(model, request);

                return StatusCode(StatusCodes.Status201Created,
                    APIResponseVO.Ok($"Stack criada com sucesso",
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
                _logService.Write($"Falha no método de criação de stack", this.GetPlace(), ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de criação de stack"));
            }
        }

        /// <summary>
        /// PUT {id} - Método para editar uma stack na base de dados, passar id pela url e dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int? id, [FromBody] SaveStackVO model)
        {
            try
            {
                RequestDataVO request = _apiInfoService.GetRequestData(Request);

                StackReturnVO result = await _stackService.UpdateAsync(id, model, request);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Stack editada com sucesso",
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
                _logService.Write($"Falha no método de edição de stack", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de edição de stack"));
            }
        }

        /// <summary>
        /// DELETE {id} - Método para deletar uma stack por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {
            try
            {
                StackReturnVO result = await _stackService.RemoveAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Stack deletada com sucesso",
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
                _logService.Write($"Falha no método de deleção de stack", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de deleção de stack"));
            }

        }

        /// <summary>
        /// GET - Método para listar stacks na base de dados, dados opcionais para paginação. Passar pela query ?limit=int page=int
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<StackReturnVO> list = await _stackService.GetAllAsync(limit, page);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Stacks listadas com scuesso", list));
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
                _logService.Write($"Falha ao listar stacks", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar stacks"));
            }
        }

        /// <summary>
        /// GET {id} - Método para listar uma stack por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            try
            {
                StackReturnVO type = await _stackService.GetByIdAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                     APIResponseVO.Ok($"Stack listada com sucesso", type));
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
                _logService.Write($"Falha ao listar stack, id: {id}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar stack, id: {id}"));
            }
        }
    }
}
