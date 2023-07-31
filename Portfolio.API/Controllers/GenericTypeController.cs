using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.GenericTypes;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenericTypeController : ControllerBase
    {
        private readonly ILogService _logService;
        private readonly IGenericTypeService _genTypeService;

        public GenericTypeController(ILogService logService, IGenericTypeService genTypeService)
        {
            _logService = logService;
            _genTypeService = genTypeService;
        }

        /// <summary>
        /// POST - Método para criar um tipo genérico na base de dados, passar dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SaveGenericTypeVO model)
        {
            try
            {
                GenericTypeVO result = await _genTypeService.CreateAsync(model);

                return StatusCode(StatusCodes.Status201Created,
                    APIResponseVO.Ok($"Tipo genérico criado com sucesso", result));
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
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha no método de criação de tipo genérico", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de criação de tipo genérico"));
            }
        }

        /// <summary>
        /// PUT {id} - Método para editar um tipo genérico na base de dados, passar id pela url e dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int? id, [FromBody] GenericTypeVO model)
        {
            try
            {
                GenericTypeVO result = await _genTypeService.EditAsync(id, model);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Tipo genérico editado com sucesso", result));
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
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha no método de edição de tipo genérico", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de edição de tipo genérico"));
            }
        }

        /// <summary>
        /// DELETE {id} - Método para deletar um tipo genérico por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {
            try
            {
                GenericTypeVO result = await _genTypeService.RemoveAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Fail($"Tipo genérico deletado com sucesso", result));
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
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha no método de deleção de tipo genérico", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de deleção de tipo genérico"));
            }

        }

        /// <summary>
        /// GET - Método para listar tipos genéricos na base de dados, dados opcionais para paginação. Passar pela query ?limit=int page=int
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<GenericTypeVO> list = await _genTypeService.GetAllAsync(limit, page);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Tipos genéricos listados com sucesso", list));
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
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar tipos genéricos", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar tipos genéricos"));
            }
        }

        /// <summary>
        /// GET {id} - Método para listar um tipo genérico por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            try
            {
                GenericTypeVO type = await _genTypeService.GetByIdAsync(id);
               
                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Tipo genérico listado com sucesso", type));
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
            catch (ConflictException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar tipos genéricos", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar tipos genéricos"));
            }
        }
    }
}
