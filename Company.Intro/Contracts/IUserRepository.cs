using Company.Intro.Models;

namespace Company.Intro.Contracts
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers(string firstName, string lastName, int skip, int take);

        User GetUserById(Guid userId);

        void InsertUser(User user);

        void DeleteUser(int userId);

        void UpdateUser(User user);

        void Save();
    }
}
