using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperienceWorkController : ControllerBase
    {
        private readonly IApiInfoService _apiInfoService;
        private readonly IExperienceWorkService _experienceWorkService;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public ExperienceWorkController(IExperienceWorkService experienceWorkService, IMapper mapper, ILogService logService, IApiInfoService apiInfoService)
        {
            _experienceWorkService = experienceWorkService;
            _mapper = mapper;
            _logService = logService;
            _apiInfoService = apiInfoService;
        }

        /// <summary>
        /// POST - Método para criar uma experiência profissional na base de dados, passar dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SaveExperienceWorkVO model)
        {
            try
            {
                RequestDataVO request = _apiInfoService.GetRequestData(Request);

                ExperienceWorkReturnVO result = await _experienceWorkService.InsertAsync(model, request);

                return StatusCode(StatusCodes.Status201Created,
                    APIResponseVO.Ok($"Experiência profissional criada com sucesso",
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
                _logService.Write($"Falha no método de criação de experiência profissional", this.GetPlace(), ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de criação de experiência profissional"));
            }
        }

        /// <summary>
        /// PUT {id} - Método para editar uma experiência profissional na base de dados, passar id pela url e dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int? id, [FromBody] SaveExperienceWorkVO model)
        {
            try
            {
                RequestDataVO request = _apiInfoService.GetRequestData(Request);

                ExperienceWorkReturnVO result = await _experienceWorkService.UpdateAsync(id, model, request);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Experiência profissional editada com sucesso",
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
                _logService.Write($"Falha no método de edição de experiência profissional", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de edição de experiência profissional"));
            }
        }

        /// <summary>
        /// DELETE {id} - Método para deletar uma experiência profissional por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {
            try
            {
                ExperienceWorkReturnVO result = await _experienceWorkService.RemoveAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Experiência profissional deletada com sucesso",
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
                _logService.Write($"Falha no método de deleção de experiência profissional", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de deleção de experiência profissional"));
            }

        }

        /// <summary>
        /// GET - Método para listar experiências profissionais na base de dados, dados opcionais para paginação. Passar pela query ?limit=int page=int
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<ExperienceWorkReturnVO> list = await _experienceWorkService.GetAllAsync(limit, page);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Experiências profissionais listados com scuesso", list));
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
                _logService.Write($"Falha ao listar experiências profissionais", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar experiências profissionais"));
            }
        }

        /// <summary>
        /// GET {id} - Método para listar uma experiência profissional por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            try
            {
                ExperienceWorkReturnVO type = await _experienceWorkService.GetByIdAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                     APIResponseVO.Ok($"Experiência profissional listada com sucesso", type));
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
                _logService.Write($"Falha ao listar experiência profissional, id: {id}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar experiência profissional, id: {id}"));
            }
        }
    }
}
