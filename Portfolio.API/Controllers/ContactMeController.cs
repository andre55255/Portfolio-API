using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ContactMe;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactMeController : ControllerBase
    {
        private readonly IContactMeService _contactMeService;
        private readonly ILogService _logService;
        private readonly IApiInfoService _apiInfoService;

        public ContactMeController(IContactMeService contactMeService, ILogService logService, IApiInfoService apiInfoService)
        {
            _contactMeService = contactMeService;
            _logService = logService;
            _apiInfoService = apiInfoService;
        }

        /// <summary>
        /// POST - Método para criar um contato na base de dados, passar dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SaveContactMeVO model)
        {
            try
            {
                RequestDataVO request = _apiInfoService.GetRequestData(Request);

                ContactMeReturnVO result = await _contactMeService.InsertAsync(model, null, request);

                return StatusCode(StatusCodes.Status201Created,
                    APIResponseVO.Ok($"Contato criado com sucesso",
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
                _logService.Write($"Falha no método de criação de contato", this.GetPlace(), ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de criação de contato"));
            }
        }

        /// <summary>
        /// PUT {id} - Método para editar um contato na base de dados, passar id pela url e dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int? id, [FromBody] SaveContactMeVO model)
        {
            try
            {
                RequestDataVO request = _apiInfoService.GetRequestData(Request);

                ContactMeReturnVO result = await _contactMeService.UpdateAsync(id, model, null, request);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Contato editado com sucesso",
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
                _logService.Write($"Falha no método de edição de contato", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de edição de contato"));
            }
        }

        /// <summary>
        /// DELETE {id} - Método para deletar um contato por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {
            try
            {
                ContactMeReturnVO result = await _contactMeService.RemoveAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Contato deletado com sucesso",
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
                _logService.Write($"Falha no método de deleção de contato", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de deleção de contato"));
            }

        }

        /// <summary>
        /// GET - Método para listar contatos na base de dados, dados opcionais para paginação. Passar pela query ?limit=int page=int
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<ContactMeReturnVO> list = await _contactMeService.GetAllAsync(limit, page);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Contatos listados com scuesso", list));
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
                _logService.Write($"Falha ao listar contatos", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar contatos"));
            }
        }

        /// <summary>
        /// GET {id} - Método para listar um contato por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            try
            {
                ContactMeReturnVO type = await _contactMeService.GetByIdAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                     APIResponseVO.Ok($"Contato listado com sucesso", type));
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
                _logService.Write($"Falha ao listar contato, id: {id}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar contato, id: {id}"));
            }
        }

        /// <summary>
        /// GetByPortfolioId - Método para listar contatos pelo id do portfolio na base de dados, dados opcionais para paginação. Passar pela url o id do portfolio
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByPortfolioIdAsync(int? id)
        {
            try
            {
                RequestDataVO request = _apiInfoService.GetRequestData(Request);

                List<ContactMeReturnVO> list = await _contactMeService.GetAllByPortfolioIdAsync(id, request);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Contatos do portfolio {id} listados com sucesso", list));
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
                _logService.Write($"Falha ao listar contatos pelo portfolio {id}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar contatos pelo portfolio {id}"));
            }
        }
    }
}
