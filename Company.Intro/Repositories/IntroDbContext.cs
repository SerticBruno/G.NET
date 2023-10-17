using System.Reflection.Metadata;
using Company.Intro.Models;
using Microsoft.EntityFrameworkCore;

namespace Company.Intro.Repositories
{
    public class IntroDbContext : DbContext
    {
        public List<User>? Users { get; set; }

        public IntroDbContext(DbContextOptions<IntroDbContext> options)
            : base(options)
        {
        }
    }
}
