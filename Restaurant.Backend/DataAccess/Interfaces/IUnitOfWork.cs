using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        IRepository<TEntity> Repository { get; }
 
        Task<int> SaveAsync();        
    }
}
