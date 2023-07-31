using AutoMapper;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Communication.ViewObjects.User;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Identity;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.ServicesImpl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, ILogService logService, IMapper mapper)
        {
            _userRepo = userRepo;
            _logService = logService;
            _mapper = mapper;
        }

        public async Task<UserWithRolesVO> CreateUserAsync(SaveUserVO model)
        {
            try
            {
                await ValidationDataSaveUserAsync(model);

                AspNetUser user = _mapper.Map<AspNetUser>(model);

                AspNetUser resultCreate = await _userRepo.CreateAsync(user, model.Roles);

                UserWithRolesVO resp = _mapper.Map<UserWithRolesVO>(resultCreate);
                resp.Roles = model.Roles;

                return resp;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao criar usuário",  this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao criar usuário", ex);
            }
        }

        public async Task<UserWithRolesVO> DeleteUserAsync(int? idUser)
        {
            try
            {
                if (!idUser.HasValue)
                    throw new ValidException($"Id de usuário a ser editado não informado na requisição");

                AspNetUser userDel = await _userRepo.DeleteAsync(idUser.Value);

                UserWithRolesVO resp = _mapper.Map<UserWithRolesVO>(userDel);
                resp.Roles = await _userRepo.GetRolesByUserAsync(idUser.Value);

                return resp;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao deletar usuário {idUser}", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao deletar usuário {idUser}", ex);
            }
        }

        public async Task<UserWithRolesVO> EditUserAsync(int? id, SaveUserVO model)
        {
            try
            {
                if (!id.HasValue)
                    throw new ValidException($"Id de usuário a ser editado não informado na requisição");

                model.Id = id.Value;
                await ValidationDataSaveUserAsync(model);

                AspNetUser user = _mapper.Map<AspNetUser>(model);

                AspNetUser result = await _userRepo.EditAsync(user, model.Roles);
                
                UserWithRolesVO resp = _mapper.Map<UserWithRolesVO>(result);
                resp.Roles = model.Roles;

                return resp;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao editar usuário",  this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao editar usuário", ex);
            }
        }

        public async Task<ListAllEntityVO<UserWithRolesVO>> GetAllUsersAsync(int? limit = null, int? page = null)
        {
            try
            {
                ListAllEntityVO<AspNetUser> usersEntity = await _userRepo.GetAllAsync(limit, page);
                if (usersEntity is null)
                    throw new NotFoundException($"Nenhum usuário encontrado na base de dados");

                ListAllEntityVO<UserWithRolesVO> response = await TransformListUserVOAsync(usersEntity);
                return response;
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar usuários", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao listar usuários", ex);
            }
        }

        public async Task<UserWithRolesVO> GetUserWithRolesAsync(int? userId = null, string userName = null, string email = null)
        {
            try
            {
                AspNetUser user = null;
                if (userId is not null)
                    user = await _userRepo.GetByIdAsync(userId.Value);
                else if (userName is not null)
                    user = await _userRepo.GetByUserNameAsync(userName);
                else if (email is not null)
                    user = await _userRepo.GetByEmailAsync(email);

                UserWithRolesVO response = _mapper.Map<UserWithRolesVO>(user);
                response.Roles = await _userRepo.GetRolesByUserAsync(user.Id);

                return response;
            }
            catch (NotFoundException ex)
            {
                throw new NotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha ao listar usuário com suas roles, {userId} {userName} {email}", this.GetPlace(), ex);
                throw new ValidException($"Falha ao listar usuário com suas roles, {userId} {userName} {email}", ex);
            }
        }

        public async Task ValidationDataSaveUserAsync(SaveUserVO model)
        {
            try
            {
                AspNetUser userExistLogin = await _userRepo.GetByUserNameAsync(model.UserName);
                if (userExistLogin is not null && userExistLogin.Id != model.Id)
                    throw new ValidException($"Nome de usuário {model.UserName} já existe na base de dados, verifique");

                AspNetUser userExistEmail = await _userRepo.GetByEmailAsync(model.Email);
                if (userExistEmail is not null && userExistEmail.Id != model.Id)
                    throw new ValidException($"Email {model.Email} já existe na base de dados, verifique");
            }
            catch (ValidException ex)
            {
                throw ex;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao validar dados enviados", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao validar dados enviados", ex);
            }
        }

        private async Task<ListAllEntityVO<UserWithRolesVO>> TransformListUserVOAsync(ListAllEntityVO<AspNetUser> usersEntity)
        {
            try
            {
                ListAllEntityVO<UserWithRolesVO> response = new ListAllEntityVO<UserWithRolesVO>();
                response.TotalPages = usersEntity.TotalPages;
                response.TotalItems = usersEntity.TotalItems;
                response.HasPreviousPage = usersEntity.HasPreviousPage;
                response.HasNextPage = usersEntity.HasNextPage;

                foreach (AspNetUser user in usersEntity.Items)
                {
                    UserWithRolesVO aux = _mapper.Map<UserWithRolesVO>(user);
                    aux.Roles = await _userRepo.GetRolesByUserAsync(user.Id);

                    response.Items.Add(aux);
                }
                return response;
            }
            catch (RepositoryException ex)
            {
                throw new ValidException(ex.Message, ex);
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao converter lista de usuários para retornar", this.GetPlace(), ex);
                throw new ValidException($"Falha inesperada ao converter lista de usuários para retornar", ex);
            }
        }
    }
}
