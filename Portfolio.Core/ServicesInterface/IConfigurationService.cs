using Portfolio.Communication.ViewObjects.Configuration;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IConfigurationService
    {
        public Task<ConfigurationVO> CreateAsync(SaveConfigurationVO modelVO);
        public Task<ConfigurationVO> EditAsync(int? id, ConfigurationVO modelVO);
        public Task<ConfigurationVO> RemoveAsync(int? id);
        public Task<ListAllEntityVO<ConfigurationVO>> GetAllAsync(int? limit = null, int? page = null);
        public Task<ConfigurationVO> GetByIdAsync(int? id);
    }
}
