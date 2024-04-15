using Company.Intro.Contracts;
using Company.Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly IntroDbContext _context;

        private bool _disposed = false;

        public UserRepository(IntroDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            _context = context;
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

        public User GetUserById(Guid userId)
        {
            return _context.Users.Find(userId);
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
        }


        public void DeleteUser(int userId)
        {
            User user = _context.Users.Find(userId);
            _context.Users.Remove(user);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
