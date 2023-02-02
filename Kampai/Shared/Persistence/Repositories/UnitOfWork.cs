using Kampai.Shared.Domain.Repositories;
using Kampai.Shared.Persistence.Context;

namespace Kampai.Shared.Persistence.Repositories;

public class UnitOfWork: IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
    
}