using Company.Intro.Models;

namespace Company.Intro.Services
{
    public interface IUserService
    {
        public List<User> Users { get; set; }
    }
}
