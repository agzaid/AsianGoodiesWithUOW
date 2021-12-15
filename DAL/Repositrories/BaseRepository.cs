using BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositrories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DataContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public BaseRepository(DataContext context, ILogger logger)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _logger = logger;
        }

        #region code with Mosh
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual bool Remove(T entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
            return true;
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return true;
        }

        #endregion

        //public async Task<T> AddAsync(T entity)
        //{
        //    await _context.Set<T>().AddAsync(entity);
        //    return entity;
        //}

        //public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        //{
        //    await _context.Set<T>().AddRangeAsync(entities);
        //    return entities;
        //}

        //public async Task<int> CountAsync()
        //{
        //    return await _context.Set<T>().CountAsync();
        //}

        //public void Delete(T entity)
        //{
        //    _context.Set<T>().Remove(entity);
        //}

        //public void DeleteRange(IEnumerable<T> entities)
        //{
        //    _context.Set<T>().RemoveRange(entities);
        //}

        //public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        //{
        //    IQueryable<T> query = _context.Set<T>();
        //    if (includes != null)
        //        foreach (var include in includes)
        //            query = query.Include(include);

        //    return await query.SingleOrDefaultAsync(criteria);
        //}


        //public async Task<IEnumerable<T>> GetAllAsync()
        //{
        //    return await _context.Set<T>().ToListAsync();
        //}

        //public async Task<T> GetByIdAsync(int id)
        //{
        //    return await _context.Set<T>().FindAsync(id);
        //}

        //public T Update(T entity)
        //{
        //    _context.Set<T>().Update(entity);
        //    return entity;
        //}
    }
}
