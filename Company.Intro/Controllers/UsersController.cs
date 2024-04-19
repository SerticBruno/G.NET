using AutoMapper;
using Company.Intro.Contracts;
using Company.Intro.DTOs;
using Company.Intro.Models;
using Company.Intro.Repositories;
using Company.Intro.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userService.GetUsers());

            return Ok(users);
        }

        [HttpGet("search")]
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
        public ActionResult<UserDto> CreateUser(User user)
        {
            var userCreated = _userService.CreateUser(user);

            if (!userCreated)
            {
                return BadRequest(user);
            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPut]
        public ActionResult<User> UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            var userUpdated = _userService.UpdateUser(user);

            if (!userUpdated)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult DeleteUser(Guid id)
        {
            if(!_userService.UserExists(id))
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
