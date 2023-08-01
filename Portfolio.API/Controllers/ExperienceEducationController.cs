using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.ExperienceEducation;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using System.Data;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperienceEducationController : ControllerBase
    {
        private readonly IApiInfoService _apiInfoService;
        private readonly IExperienceEducationService _experienceEducationService;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;

        public ExperienceEducationController(IApiInfoService apiInfoService, IExperienceEducationService experienceEducationService, IMapper mapper, ILogService logService)
        {
            _apiInfoService = apiInfoService;
            _experienceEducationService = experienceEducationService;
            _mapper = mapper;
            _logService = logService;
        }



        /// <summary>
        /// POST - Método para criar uma experiência educacional na base de dados, passar dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SaveExperienceEducationVO model)
        {
            try
            {
                RequestDataVO request = _apiInfoService.GetRequestData(Request);

                ExperienceEducationReturnVO result = await _experienceEducationService.InsertAsync(model, request);

                return StatusCode(StatusCodes.Status201Created,
                    APIResponseVO.Ok($"Experiência educacional criada com sucesso",
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
                _logService.Write($"Falha no método de criação de experiência educacional", this.GetPlace(), ex);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de criação de experiência educacional"));
            }
        }

        /// <summary>
        /// PUT {id} - Método para editar uma experiência educacional na base de dados, passar id pela url e dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int? id, [FromBody] SaveExperienceEducationVO model)
        {
            try
            {
                RequestDataVO request = _apiInfoService.GetRequestData(Request);

                ExperienceEducationReturnVO result = await _experienceEducationService.UpdateAsync(id, model, request);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Experiência educacional editada com sucesso",
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
                _logService.Write($"Falha no método de edição de experiência educacional", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de edição de experiência educacional"));
            }
        }

        /// <summary>
        /// DELETE {id} - Método para deletar uma experiência educacional por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int? id)
        {
            try
            {
                ExperienceEducationReturnVO result = await _experienceEducationService.RemoveAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Experiência educacional deletada com sucesso",
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
                _logService.Write($"Falha no método de deleção de experiência educacional", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha no método de deleção de experiência educacional"));
            }

        }

        /// <summary>
        /// GET - Método para listar experiências educacionais na base de dados, dados opcionais para paginação. Passar pela query ?limit=int page=int
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<ExperienceEducationReturnVO> list = await _experienceEducationService.GetAllAsync(limit, page);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Experiências educacionais listados com scuesso", list));
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
                _logService.Write($"Falha ao listar experiências educacionais", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar experiências educacionais"));
            }
        }

        /// <summary>
        /// GET {id} - Método para listar uma experiência educacional por id na base de dados, passar id pela url
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int? id)
        {
            try
            {
                ExperienceEducationReturnVO type = await _experienceEducationService.GetByIdAsync(id);

                return StatusCode(StatusCodes.Status200OK,
                     APIResponseVO.Ok($"Experiência educacional listada com sucesso", type));
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
                _logService.Write($"Falha ao listar experiência educacional, id: {id}", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha ao listar experiência educacional, id: {id}"));
            }
        }
    }
}
