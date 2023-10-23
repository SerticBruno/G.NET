using Company.Intro.Contracts;
using Company.Intro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Intro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = _userService.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User userDTO)
        {
            var user = await _userService.CreateUserAsync(userDTO);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User userDTO)
        {
            var user = await _userService.UpdateUserAsync(userDTO);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            bool result = await _userService.DeleteUserAsync(id);

            if (result)
            {
                // user should be delete here
                return Ok();
            }

            return NotFound();
        }
    }
}
