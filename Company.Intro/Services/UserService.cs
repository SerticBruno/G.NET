using Company.Intro.Contracts;
using Company.Intro.Models;
using Company.Intro.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Services
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository { get; set; }

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers(string firstName, string lastName, int skip, int take)
        {
            return _userRepository.GetUsers(firstName, lastName, skip, take);
        }

        public User GetUserById(Guid id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
