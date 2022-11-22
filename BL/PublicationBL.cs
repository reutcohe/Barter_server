using AutoMapper;
using BL;
using DAL.Models;
using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
    public class PublicationBL
    {
        IPublicationDAL _publicationDAL;
        IMapper _mapper;
        public PublicationBL(IPublicationDAL publicationDAL)
        {
            _publicationDAL= publicationDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            _mapper = config.CreateMapper();
        }
        public PublicationDTO GetPublicationById
    }
}
//public List<UserDTO> GetAllUsers()
//{
//    List<User> listUsers = _userDal.GetAllUsers();

//    return mapper.Map<List<UserDTO>>(listUsers);
//}
//public UserDTO GetUserById(int id)
//{

//    try
//    {
//        var User = _userDal.GetUserById(id);
//        return mapper.Map<UserDTO>(User);
//    }
//    catch (Exception ex)
//    {
//        throw ex;
//    }
//}

//public bool AddUser(UserDTO user)
//{
//    return _userDal.AddUser(mapper.Map<UserDTO, User>(user));

//}
//public bool DeleteUser(int id)
//{
//    return _userDal.DeleteUser(id);

//}

//public bool UpdateUser(int id, UserDTO user)
//{
//    User user1 = mapper.Map<UserDTO, User>(user);
//    return _userDal.UpdateUsers(id, user1);
//}
//    }
//}