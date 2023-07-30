using Portfolio.Core.Entities.Identity;

namespace Portfolio.Core.RepositoriesInterface.Sql
{
    public interface IRoleRepository
    {
        public Task<List<AspNetRole>> GetAllRoles();
    }
}
