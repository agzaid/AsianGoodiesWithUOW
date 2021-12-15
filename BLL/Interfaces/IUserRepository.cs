using BLL.Models;
using System;



using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{

    public interface IUserRepository:IBaseRepository<User>
    {
        IEnumerable<User> GetTopFavoriteUsers(int count);
        IEnumerable<User> GetUsersWithProducts(int pageIndex, int pageSize);

    }
}
