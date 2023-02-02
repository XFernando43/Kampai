using Kampai.Licors.Domain.Model;
using Kampai.Licors.Domain.Repositories;
using Kampai.Licors.Domain.Repositories.Communication;
using Kampai.Licors.Domain.Services;
using Kampai.Shared.Domain.Repositories;

namespace Kampai.Licors.Services;

public class LicorService: ILicorService
{
    private readonly ILicorRepository _licorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LicorService(IUnitOfWork unitOfWork, ILicorRepository licorRepository)
    {
        _unitOfWork = unitOfWork;
        _licorRepository= licorRepository;
    }

    public async Task<IEnumerable<Licor>> ListAsync()
    {
        return await _licorRepository.ListAsync();
    }

    public async Task<LicorResponse> SaveAsync(Licor licor)
    {
        try
        {
            await _licorRepository.AddAsync(licor);
            await _unitOfWork.CompleteAsync();

            return new LicorResponse(licor);
        }
        catch (Exception e)
        {
            return new LicorResponse("$ AN ERROR OCURRED WHILE SAVIG THE NEW CLASS");
        }
    }

    public async Task<LicorResponse> UpdateAsync(int id, Licor licor)
    {
        var existingLicor = await _licorRepository.FindByIdAsync(id);
        if (existingLicor == null)
        {
            return new LicorResponse("$ AN ERROR OCURRED WHILE SAVIG THE NEW CLASS");
        }
        existingLicor.name = licor.name;
        existingLicor.description = licor.description;
        existingLicor.price = licor.price;
        
        try
        {
            _licorRepository.UpdateLicor(existingLicor);
            await _unitOfWork.CompleteAsync();

            return new LicorResponse(existingLicor);
        }
        catch (Exception e)
        { 
            return new LicorResponse("$ AN ERROR OCURRED WHILE SAVIG THE NEW CLASS");
        }
    }

    public async Task<LicorResponse> DeleteAsync(int id)
    {
        var existingPet = await _licorRepository.FindByIdAsync(id);
        if (existingPet == null)
        {
            return new LicorResponse("Licor not Found");
        }

        try
        {
            _licorRepository.RemoveLicor(existingPet);
            await _unitOfWork.CompleteAsync();

            return new LicorResponse(existingPet);
        }
        catch (Exception e)
        {
            return new LicorResponse($"An Error occurred while deleting the Licor: {e.Message}");
        }
    }
}