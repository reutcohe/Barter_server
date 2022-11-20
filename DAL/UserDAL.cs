using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUserDAL
    {

        BartersDBContext bartersDBContext = new BartersDBContext();
        public List<User> GetAllUsers()
        {
            //select * from Users; 
            try
            {
                var Users = bartersDBContext.Users.ToList();
                return Users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserById(int id)
        {
            //select * from Users; 
            try
            {
                var User = bartersDBContext.Users.SingleOrDefault(x => x.Id == id);
                return User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
