using Company.Intro.Contracts;
using Company.Intro.Models;
using Company.Intro.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Services
{
    public class UserService : IUserService
    {
        public IntroDbContext _context { get; set; }
        public DbSet<User>? Users { get; set; }

        public UserService(IntroDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var newUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }
    }
}
