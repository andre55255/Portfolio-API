using Portfolio.Core.Entities.Identity;
using Portfolio.Core.RepositoriesInterface.Sql;

namespace Portfolio.Infrastructure.RepositoriesImpl.Sql
{
    public class RoleRepository : IRoleRepository
    {
        public Task<List<AspNetRole>> GetAllRoles()
        {
            throw new NotImplementedException();
        }
    }
}
