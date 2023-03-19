using HueFes.DomainModels;

namespace HueFes.Core.IServices
{
    public interface IShowCategoryService
    {
        Task<IEnumerable<ShowCategory>> GetAll();
        Task<ShowCategory> GetById(int id);
        Task<bool> Add(ShowCategory input);
        Task<bool> Delete(int id);
        Task<bool> Update(ShowCategory input);
    }
}
