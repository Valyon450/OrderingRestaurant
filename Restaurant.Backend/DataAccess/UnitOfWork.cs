using DataAccess.Entities;
using DataAccess.Interfaces;

namespace DataAccess
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        private readonly RestaurantDbContext _context;
        public IRepository<TEntity> Repository { get;}

        public UnitOfWork(RestaurantDbContext context, IRepository<TEntity> repository)
        {
            _context = context;
            Repository = repository;
        }        

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
