using Company.Intro.Models;
using Company.Intro.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Company.Intro.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<int> CommitAsync();
        void Rollback();
    }
}
