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
        public async Task<User> GetUserAsync(Guid id)
        {
            if (_context is null)
            {
                throw new InvalidOperationException("Database context is not initialized.");
            }

            if (_context.Users is null)
            {
                throw new InvalidOperationException("Users DbSet is not initialized.");
            }

            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser is null)
            {
                throw new InvalidOperationException("User not found.");
            }

            return existingUser;
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

            if (_context is null)
            {
                throw new InvalidOperationException("Database context is not initialized.");
            }

            if (_context.Users is null)
            {
                throw new InvalidOperationException("Users DbSet is not initialized.");
            }

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> UpdateUserAsync(User updatedUser)
        {
            if (_context is null)
            {
                throw new InvalidOperationException("Database context is not initialized.");
            }

            if (_context.Users is null)
            {
                throw new InvalidOperationException("Users DbSet is not initialized.");
            }

            var existingUser = await _context.Users.FindAsync(updatedUser.Id);

            if (existingUser is null)
            {
                // Handle the case where the user to update does not exist.
                // You can throw an exception or return an appropriate response.
                throw new InvalidOperationException("User not found.");
            }

            // Update the user properties.
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Age = updatedUser.Age;

            // Save the changes to the database.
            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            if (_context is null)
            {
                throw new InvalidOperationException("Database context is not initialized.");
            }

            if (_context.Users is null)
            {
                throw new InvalidOperationException("Users DbSet is not initialized.");
            }

            var existingUser = await _context.Users.FindAsync(userId);

            if (existingUser is null)
            {
                // Handle the case where the user to update does not exist.
                // You can throw an exception or return an appropriate response.
                throw new InvalidOperationException("User not found.");
            }

            _context.Users.Remove(existingUser);

            int result = await _context.SaveChangesAsync();

            return result == 1;
        }
    }
}
