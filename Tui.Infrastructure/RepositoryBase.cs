using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tui.Domain;

namespace Tui.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        TuiContext _context;

        public RepositoryBase(TuiContext context)
        {
            _context = context;

        }
        public T Create(T model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }

        public async Task<T> CreateAsync(T model)
        {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }


        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            IQueryable<T> set = _context.Set<T>();
            includes.ToList().ForEach(i => set = set.Include(i));

            return predicate == null ? await set.ToListAsync() : await set.Where(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> set = _context.Set<T>();
            includes.ToList().ForEach(i => set = set.Include(i));
            var result = set.Where(predicate);
            return await set.AsNoTracking().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> UpdateAsync(T model)
        {
            _context.Entry(model);
            _context.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
