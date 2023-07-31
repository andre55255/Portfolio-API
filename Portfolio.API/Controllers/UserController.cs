using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.User;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, ILogService logService, IMapper mapper)
        {
            _userService = userService;
            _logService = logService;
            _mapper = mapper;
        }

        /// <summary>
        /// POST - Método para criar um usuário na base de dados, passar dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SaveUserVO model)
        {
            try
            {
                UserWithRolesVO result = await _userService.CreateUserAsync(model);

                return StatusCode(StatusCodes.Status201Created,
                    APIResponseVO.Ok($"Usuário criado com sucesso",
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
                _logService.Write($"Falha inesperada no método de criação de usuário", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada no método de criação de usuário"));
            }
        }

        /// <summary>
        /// PUT {id} - Método para editar um usuário na base de dados, passar id pela url e dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int? id, [FromBody] SaveUserVO model)
        {
            try
            {
                UserWithRolesVO result = await _userService.EditUserAsync(id, model);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Usuário editado com sucesso",
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
                _logService.Write($"Falha no método de edição de usuário", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de edição de usuário"));
            }
        }

        /// <summary>
        /// DELETE {id} - Método para deletar um usuário por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {
            try
            {
                UserWithRolesVO result = await _userService.DeleteUserAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Usuário deletado com sucesso",
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
                _logService.Write($"Falha inesperada no método de deleção de usuário", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada no método de deleção de usuário"));
            }

        }

        /// <summary>
        /// GET - Método para listar usuários na base de dados, dados opcionais para paginação. Passar pela query ?limit=int page=int
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<UserWithRolesVO> list = await _userService.GetAllUsersAsync(limit, page);
                
                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Usuários listados com scuesso", list));
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
                _logService.Write($"Falha inesperada ao listar usuários", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao listar usuários"));
            }
        }

        /// <summary>
        /// GET {id} - Método para listar um usuário por id, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            try
            {
                UserWithRolesVO type = await _userService.GetUserWithRolesAsync(id);
                SaveUserVO user = _mapper.Map<SaveUserVO>(type);

                return StatusCode(StatusCodes.Status200OK,
                     APIResponseVO.Ok($"Usuário listado com scuesso", user));
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
                _logService.Write($"Falha ao listar usuário por id", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar usuário por id"));
            }
        }
    }
}
