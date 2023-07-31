using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Communication.CustomExceptions;
using Portfolio.Core.Entities.Identity;
using Portfolio.Core.RepositoriesInterface.Sql;
using Portfolio.Core.ServicesInterface;
using Portfolio.Helpers;

namespace Portfolio.Infrastructure.RepositoriesImpl.Sql
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<AspNetRole> _roleManager;
        private readonly ILogService _logService;

        public RoleRepository(RoleManager<AspNetRole> roleManager, ILogService logService)
        {
            _roleManager = roleManager;
            _logService = logService;
        }

        public async Task<List<AspNetRole>> GetAllRoles()
        {
            try
            {
                List<AspNetRole> roles =
                    await _roleManager
                               .Roles
                               .OrderBy(x => x.Name)
                               .AsNoTracking()
                               .ToListAsync();

                return roles;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logService.Write($"Falha inesperada ao listar perfis no banco de dados", this.GetPlace(), ex);
                throw new RepositoryException($"Falha inesperada ao perfis usuários no banco de dados", ex);
            }
        }
    }
}
