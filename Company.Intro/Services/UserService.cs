using Company.Intro.Models;

namespace Company.Intro.Services
{
    public class UserService : IUserService
    {
        public List<User> Users { get; set; }

        public UserService()
        {
            Users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Dolly",
                    LastName = "Pas",
                    Age = 3,
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Dobby",
                    LastName = "Psic",
                    Age = 4,
                }
            };
        }
    }
}
