using Company.Intro.DTOs;
using Company.Intro.Models;

namespace Company.Intro.Contracts
{
    public interface IUserRepository
    {

        IEnumerable<User> GetUsers();

        IEnumerable<User> GetUsers(string firstName, string lastName, int skip, int take);

        User? GetUserById(Guid userId);

        bool CreateUser(User user);

        bool UpdateUser(User user);

        bool DeleteUser(Guid userId);
        
        bool UserExists(Guid id);
    }
}
