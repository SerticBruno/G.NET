using Company.Intro.Contracts;
using Company.Intro.DTOs;
using Company.Intro.Models;
using Company.Intro.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.Users.GetUsers();
        }

        public IEnumerable<User> GetUsers(string firstName, string lastName, int skip, int take)
        {
            return _unitOfWork.Users.GetUsers(firstName, lastName, skip, take);
        }

        public User GetUserById(Guid id)
        {
            return _unitOfWork.Users.GetUserById(id);
        }

        public bool CreateUser(User user)
        {
            var created = _unitOfWork.Users.CreateUser(user);

            if (!created)
            {
                return false;
            }
            
            _unitOfWork.CommitAsync();
            return true;
        }

        public bool UpdateUser(User user)
        {
            var updated = _unitOfWork.Users.UpdateUser(user);
            if (updated)
            {
                _unitOfWork.CommitAsync();
            }
            return updated;
        }

        public bool DeleteUser(Guid id)
        {
            var deleted = _unitOfWork.Users.DeleteUser(id);
            if (deleted)
            {
                _unitOfWork.CommitAsync();
            }
            return deleted;
        }

        public bool UserExists(Guid id)
        {
            return _unitOfWork.Users.UserExists(id);
        }
    }
}
