using HueFes.DomainModels;

namespace HueFes.Core.IServices
{
    public interface ILocationCategoryService
    {
        Task<IEnumerable<LocationCategory>> GetAll();
        Task<LocationCategory> GetById(int id);
        Task<bool> Add(LocationCategory locationCategory);
        Task<bool> Delete(int id);
        Task<bool> Update(LocationCategory locationCategory);
    }
}
