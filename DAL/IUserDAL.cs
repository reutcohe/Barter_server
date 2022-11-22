using DAL.Models;
using System.Collections.Generic;

namespace DAL
{
    public interface IUserDAL
    {

        List<User> GetAllUsers();
        User GetUserById(int id);




    }
}