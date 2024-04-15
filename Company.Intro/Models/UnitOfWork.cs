using Company.Intro.Contracts;
using Company.Intro.Repositories;

namespace Company.Intro.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IntroDbContext _context;

        public UnitOfWork(IntroDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }


        public void Rollback()
        {
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
