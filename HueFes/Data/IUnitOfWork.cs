using HueFes.Core.IRepositories;

namespace HueFes.Data
{
    public interface IUnitOfWork
    {
        ILocationRepository LocationRepository { get; }
        ILocationCategoryRepository LocationCategoryRepository { get; }
        IEventRepository EventRepository { get; }
        IShowRepository ShowRepository { get; }
        IShowCategoryRepository ShowCategoryRepository { get; }
        IEventImageRepository EventImageRepository { get; }

        void Commit();
        void RollBack();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
