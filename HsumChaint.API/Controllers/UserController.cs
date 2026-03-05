using HsumChaint.Application.DTOs;
using HsumChaint.Application.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HsumChaint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> GetAddUser(UserDto reqModel)
        {
            var user = await _userService.AddUser(reqModel);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
