using Kampai.Licors.Domain.Model;
using Kampai.Licors.Domain.Repositories.Communication;

namespace Kampai.Licors.Domain.Services;

public interface ILicorService
{
    Task<IEnumerable<Licor>> ListAsync();
    Task<LicorResponse> SaveAsync(Licor licor);
    Task<LicorResponse> UpdateAsync(int id, Licor licor);
    Task<LicorResponse> DeleteAsync(int id);
}