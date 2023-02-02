using Kampai.Licors.Domain.Model;
using Kampai.Licors.Domain.Repositories;
using Kampai.Shared.Domain.Services.Communication;
using Kampai.Shared.Persistence.Context;
using Kampai.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Kampai.Licors.Persistence.Repositories;

public class LicorRepository: BaseRepository, ILicorRepository
{
    public LicorRepository(AppDbContext context) : base(context)
    {
        
    }
    
    public async Task<IEnumerable<Licor>> ListAsync()
    {
        return await _context.licor.ToListAsync();
    }

    public async Task AddAsync(Licor licor)
    {
        await _context.licor.AddAsync(licor);
    }

    public async Task<Licor> FindByIdAsync(int id)
    {
        return await _context.licor.FindAsync(id);
    }

    public void UpdateLicor(Licor licor)
    {
        _context.licor.Update(licor);
    }

    public void RemoveLicor(Licor licor)
    {
        _context.licor.Remove(licor);
    }
}