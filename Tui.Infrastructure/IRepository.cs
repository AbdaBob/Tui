using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tui.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params string[] includes);
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params string[] includes);
    }
}
