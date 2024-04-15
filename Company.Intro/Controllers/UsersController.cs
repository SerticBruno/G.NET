using Company.Intro.Contracts;
using Company.Intro.Models;
using Company.Intro.Repositories;
using Company.Intro.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Intro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get([FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var users = _userService.GetUsers(firstName, lastName, skip, take);
            return Ok(users);
        }   

        [HttpGet("{id}")]
        public ActionResult<User> GetById(Guid id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    }
}
