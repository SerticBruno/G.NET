using Company.Intro.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Company.Intro.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
