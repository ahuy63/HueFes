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
        IHelpMenuRepository HelpMenuRepository { get; }
        INewsRepository NewsRepository { get; }
        IFavouriteRepository FavouriteRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ITicketRepository TicketRepository { get; }
        ITicketTypeRepository TicketTypeRepository { get; }


        void Commit();
        void RollBack();
        Task CommitAsync();
        Task RollBackAsync();
    }
}
