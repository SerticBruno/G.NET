using Company.Intro.Models;
using Company.Intro.Repositories;
using Company.Intro.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Intro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IntroDbContext _context;

        public UsersController(IUserService userService, IntroDbContext context)
        {
            _userService = userService;
            _context = context;
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
    }
}
