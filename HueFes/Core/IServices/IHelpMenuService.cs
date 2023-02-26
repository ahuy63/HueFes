using HueFes.Models;

namespace HueFes.Core.IServices
{
    public interface IHelpMenuService
    {
        Task<IEnumerable<HelpMenu>> GetAll();
        Task<HelpMenu> GetById(int id);
        Task<bool> Add(HelpMenu input);
        Task<bool> Delete(int id);
        Task<bool> Update(HelpMenu input);
    }
}
