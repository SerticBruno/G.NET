using Company.Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Contracts
{
    public interface IUserService
    {
        public DbSet<User>? Users { get; set; }
        Task<User> GetUserAsync(Guid id);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
