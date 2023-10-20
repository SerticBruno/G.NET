using Company.Intro.Models;

namespace Company.Intro.Contracts
{
    public interface IUserService
    {
        public List<User> Users { get; set; }
    }
}
