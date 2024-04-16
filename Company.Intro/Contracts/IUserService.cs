using Company.Intro.DTOs;
using Company.Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(string firstName, string lastName, int skip, int take);
        User GetUserById(Guid id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
    }
}
