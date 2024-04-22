using Company.Intro.Contracts;
using Company.Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IntroDbContext _context;

        public UserRepository(IntroDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<User> GetUsers(string firstName, string lastName, int skip, int take)
        {
            return _context.Users
                .Where(u => string.IsNullOrWhiteSpace(firstName) || EF.Functions.Like(u.FirstName, $"%{firstName}%"))
                .Where(u => string.IsNullOrWhiteSpace(lastName) || EF.Functions.Like(u.LastName, $"%{lastName}%"))
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public User? GetUserById(Guid userId)
        {
            return _context.Users.Find(userId);
        }

        public bool CreateUser(User user)
        {
            if (_context.Users.Any(u => u.Id == user.Id))
            {
                return false; // User with this ID already exists
            }

            var createdUser = _context.Users.Add(user);

            if(createdUser is not null)
            {
                return true;
            }

            return false;
        }

        public bool DeleteUser(Guid userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            return true;
        }

        public bool UpdateUser(User user)
        {
            var usera = _context.Users.Update(user);

            if (usera is not null)
            {
                return true;
            }

            return false;
        }

        public bool UserExists(Guid id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
