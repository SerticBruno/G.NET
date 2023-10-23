using Company.Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Contracts
{
    public interface IUserService
    {
        public DbSet<User>? Users { get; set; }
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
    }
}
