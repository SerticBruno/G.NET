using Company.Intro.DTOs;
using Company.Intro.Models;

namespace Company.Intro.Contracts
{
    public interface IUserRepository : IDisposable
    {

        IEnumerable<User> GetUsers();

        IEnumerable<User> GetUsers(string firstName, string lastName, int skip, int take);

        User GetUserById(Guid userId);

        bool CreateUser(User user);

        void DeleteUser(int userId);

        void UpdateUser(User user);

        bool Save();
    }
}
