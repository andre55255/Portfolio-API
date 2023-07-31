using Portfolio.Communication.ViewObjects.GenericTypes;
using Portfolio.Communication.ViewObjects.Utlis;

namespace Portfolio.Core.ServicesInterface
{
    public interface IGenericTypeService
    {
        public Task<GenericTypeVO> CreateAsync(SaveGenericTypeVO modelVO);
        public Task<GenericTypeVO> EditAsync(int? id, SaveGenericTypeVO modelVO);
        public Task<GenericTypeVO> RemoveAsync(int? id);
        public Task<ListAllEntityVO<GenericTypeVO>> GetAllAsync(int? limit = null, int? page = null);
        public Task<GenericTypeVO> GetByIdAsync(int? id);
    }
}
