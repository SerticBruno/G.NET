using Company.Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers(string firstName, string lastName, int skip, int take);
        User GetUserById(Guid id);
    }
}
