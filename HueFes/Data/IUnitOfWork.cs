using HueFes.Core.IRepositories;

namespace HueFes.Data
{
    public interface IUnitOfWork
    {
        ILocationRepository LocationRepository { get; }
        ILocationCategoryRepository LocationCategoryRepository { get; }


        void Commit();
        void RollBack();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
