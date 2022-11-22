using BL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserBL _userBL;
        public UsersController(IUserBL userBL)
        {
            _userBL = userBL;
        }
        [HttpGet]
        [Route("GetAllUsers")]
        public ActionResult<List<UserDTO>> GetAllUsers()
        {
            List<UserDTO> users = _userBL.GetAllUsers();
            if (users == null)
                return NotFound();
            return Ok(users);
        }
        [HttpGet]
        [Route("GetUserById")]
        public ActionResult<UserDTO> GetUserById( int id)
        {
           UserDTO user = _userBL.GetUserById(id);

            if (user == null)
                return NotFound();
            return Ok(user);
        }

    }
}
