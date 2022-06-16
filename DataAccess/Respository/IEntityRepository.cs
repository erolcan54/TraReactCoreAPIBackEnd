using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Respository
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
