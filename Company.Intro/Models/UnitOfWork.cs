using Company.Intro.Contracts;
using Company.Intro.Repositories;
using Microsoft.EntityFrameworkCore;

public class UnitOfWork : IUnitOfWork
{
    private readonly IntroDbContext _context;
    private IUserRepository _userRepository;

    public UnitOfWork(IntroDbContext context)
    {
        _context = context;
    }
    public IUserRepository Users => _userRepository ??= new UserRepository(_context);

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Rollback()
    {
        // EF Core rolls back transactions automatically if SaveChangesAsync throws an exception
        // Otherwise, for manual rollback, you might need additional logic here
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
