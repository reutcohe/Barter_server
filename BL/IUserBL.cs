using DTO;
using System.Collections.Generic;

namespace BL
{
    public interface IUserBL
    {
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int id);


    }
}