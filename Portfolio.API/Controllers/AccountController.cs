using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.Account;
using Portfolio.Communication.ViewObjects.User;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;
using Portfolio.Infrastructure.ServicesImpl;
using System.Data;
using System.Security.Authentication;

namespace Portfolio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IApiInfoService _apiInfoService;
        private readonly IAccountService _accService;
        private readonly IUserService _userService;
        private readonly ILogService _logService;

        public AccountController(IAccountService accService, ILogService logService, IUserService userService, IApiInfoService apiInfoService)
        {
            _accService = accService;
            _logService = logService;
            _userService = userService;
            _apiInfoService = apiInfoService;
        }

        /// <summary>
        /// Login - Método para realizar login de usuário no sistema, passar dados pelo body
        /// </summary>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginVO model)
        {
            try
            {
                LoginResponseTokenVO response = await _accService.LoginAsync(model);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Login efetuado com sucesso",
                        response));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao efetuar login", this.GetPlace(), ex);

                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao efetuar login"));
            }
        }

        /// <summary>
        /// Refresh - Método para realizar refresh token, passar dados no body
        /// </summary>
        [HttpPost]
        [Route("Refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenVO model)
        {
            try
            {
                RefreshTokenVO token = await _accService.RefreshTokenAsync(model);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Token atualizado com sucesso", 
                        token));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao efetuar refresh token", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao refresh token"));
            }
        }

        /// <summary>
        /// UserInfo - Método para recuperar dados do usuário logado atualmente, sem parâmetros
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        [Route("UserInfo")]
        public async Task<IActionResult> UserInfoAsync()
        {
            try
            {
                RequestDataVO data = _apiInfoService.GetRequestData(Request);
                UserInfoVO user = await _accService.GetUserInfoAsync(data.User.Id);
                
                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Informações de usuário listadas com sucesso", user));
            }
            catch (AuthenticationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar dados de usuário", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao listar dados de usuário"));
            }
        }

        /// <summary>
        /// ResetPasswordSignIn - Método para redefinir a senha do usuário logado atualmente, passar dados pelo body
        /// </summary>
        [Authorize(Roles = "Admin, User")]
        [HttpPost]
        [Route("ResetPasswordSignIn")]
        public async Task<IActionResult> ResetPasswordSignInAsync([FromBody] ResetPasswordSignInVO modelVO)
        {
            try
            {
                RequestDataVO data = _apiInfoService.GetRequestData(Request);
                await _accService.ResetPasswordSignInUserAsync(data.User.Id, modelVO);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Senha de {data.User.Username} redefinida com sucesso"));
            }
            catch (AuthenticationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao redefinir a senha", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao redefinir a senha"));
            }
        }

        /// <summary>
        /// ForgotPassword - Método para esqueceu sua senha, passar dados pelo body
        /// </summary>
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordVO model)
        {
            try
            {
                string emailRes = await _accService.ForgotPasswordSendMailAsync(model);

                return StatusCode(StatusCodes.Status200OK,
                    APIResponseVO.Ok($"Senha redefinida com sucesso, email com nova senha envaido pra {emailRes}"));
            }
            catch (AuthenticationException ex)
            {
                return StatusCode(StatusCodes.Status401Unauthorized,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (ValidException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    APIResponseVO.Fail(ex.Message));
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao redefinir a senha", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao redefinir a senha"));
            }
        }

        /// <summary>
        /// Register - Método para criar conta de usuário, passar dados pelo body
        /// </summary>
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserVO model)
        {
            try
            {
                UserWithRolesVO result = await _accService.RegisterUserAsync(model);

                return StatusCode(StatusCodes.Status201Created,
                    APIResponseVO.Ok($"Usuário registrado com sucesso",
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
                _logService.Write($"Falha inesperada ao registrar usuário", this.GetPlace(), ex);
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                    APIResponseVO.Fail($"Falha inesperada ao registrar usuário"));
            }
        }
    }
}
