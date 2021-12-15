using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        //Task<T> GetByIdAsync(int id);
        //Task<IEnumerable<T>> GetAllAsync();
        //Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        //Task<T> AddAsync(T entity);
        //Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        ////T Update(T entity);
        ////void Delete(T entity);
        //void DeleteRange(IEnumerable<T> entities);
        //Task<int> CountAsync();



     #region code with Mosh
        bool Remove(T entityToDelete);
        bool RemoveRange(IEnumerable<T> entities);

        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

     #endregion

    }
}
