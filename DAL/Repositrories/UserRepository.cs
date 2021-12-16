using BLL.Interfaces;
using BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositrories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context, ILogger logger): base(context, logger)
        {
        }
        #region own IUserRepository methods
        public IEnumerable<User> GetTopFavoriteUsers(int count)
        {
            return _context.Users.OrderByDescending(c => c.firstName).Take(count).ToList();
        }

        public IEnumerable<User> GetUsersWithProducts(int pageIndex, int pageSize=10)
        {
            return _context.Users.Include(c => c.Products).OrderBy(c => c.firstName).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        #endregion
        public override async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch ( Exception ex)
            {

                _logger.LogError(ex, "{Repo} All method error", typeof(UserRepository));
                return new List<User>();
            }
        }
        //public override User Get(int id)
        //{
        //    try
        //    {
        //        return _dbSet.Find(id);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
            
        //}
        public override void Add(User entity)
        {
            try
            {
                var existEntity = _dbSet.Where(s => s.Id == entity.Id).FirstOrDefault();
                if (existEntity == null)
                {
                    _dbSet.Add(entity);
                }
                else
                {
                    existEntity.firstName = entity.firstName;
                    existEntity.LastName = entity.LastName;
                    existEntity.Products = entity.Products;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add method error", typeof(UserRepository));
            }
        }
        public override bool Remove(User entityToDelete)
        {
            try
            {
                var existEntity = _dbSet.Where(s => s.Id == entityToDelete.Id).FirstOrDefault();
                if (existEntity!=null)
                {
                    _dbSet.Remove(existEntity);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Remove method error", typeof(UserRepository));
                return false;
            }
        }
    }
}
