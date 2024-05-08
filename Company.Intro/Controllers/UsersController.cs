using AutoMapper;
using Company.Intro.Application.Contracts;
using Company.Intro.Application.Contracts.Models;
using Company.Intro.Infrastructure.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Company.Intro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<ActionResult<List<UserDto>>> GetUsers(CancellationToken cancellation)
        {
            var users = await _userService.GetUsers(cancellation);

            return Ok(users);
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(User), 400)]
        public ActionResult<IEnumerable<User>> GetUsers([FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            var users = _mapper.Map<List<UserDto>>(_userService.GetUsers(firstName, lastName, skip, take));

            if (users.Count == 0)
            {
                return BadRequest();
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        [ProducesResponseType(typeof(User), 404)]
        public ActionResult<User> GetById(Guid id)
        {
            var user = _mapper.Map<UserDto>(_userService.GetUserById(id));

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(UserDto), 400)]
        [ProducesResponseType(typeof(UserDto), 409)]
        public ActionResult<UserDto> CreateUser(UserDto user)
        {
            var userCreated = _userService.CreateUser(user);

            
            if (!userCreated)
            {
                return BadRequest(user);
            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPut]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(UserDto), 400)]
        [ProducesResponseType(typeof(UserDto), 409)]
        public ActionResult<User> UpdateUser(UserDto userDto)
        {

            var userUpdated = _userService.UpdateUser(userDto);

            if (!userUpdated)
            {
                return BadRequest();
            }
            return Ok(userUpdated);
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult DeleteUser(Guid id)
        {
            if (!_userService.UserExists(id))
            {
                return NotFound($"No user with id: {id}");
            }

            var userDeleted = _userService.DeleteUser(id);

            if (userDeleted)
            {
                return Ok("User deleted");
            }

            return BadRequest(id);
        }
    }
}
