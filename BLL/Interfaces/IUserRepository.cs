using BLL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable GetUsers();
        User GetUserByID(int UserId);
        void InsertUser(User User);
        void DeleteUser(int UserId);
        void UpdateUser(User user);
        void Save();
    }
}
