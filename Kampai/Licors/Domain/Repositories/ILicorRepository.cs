using Kampai.Licors.Domain.Model;

namespace Kampai.Licors.Domain.Repositories;

public interface ILicorRepository
{
    Task<IEnumerable<Licor>> ListAsync();
    Task AddAsync(Licor licor);
    Task<Licor> FindByIdAsync(int id);
    void UpdateLicor(Licor pet);
    void RemoveLicor(Licor pet);
}