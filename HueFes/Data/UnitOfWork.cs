using HueFes.Core.IRepositories;
using HueFes.Core.Repositories;

namespace HueFes.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HueFesDbContext _context;

        public ILocationRepository LocationRepository { get; private set; }
        public ILocationCategoryRepository LocationCategoryRepository { get; private set; }

        public UnitOfWork(HueFesDbContext context)
        {
            _context = context;
            LocationRepository = new LocationRepository(_context);
            LocationCategoryRepository= new LocationCategoryRepository(_context);

        }



        public void Commit() => _context.SaveChanges();
        public async Task CommitAsync() => await _context.SaveChangesAsync();
        public void RollBack() => _context.Dispose();
        public async Task RollBackAsync() => await _context.DisposeAsync();
    }
}
