
using AutoMapper;
using Kampai.Licors.Domain.Model;
using Kampai.Licors.Domain.Services;
using Kampai.Licors.Resources;
using Kampai.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder.Extensions;
namespace Kampai.Licors.Controller;

[Route("api/v1/[controller]")]
public class LicorController : ControllerBase
{
    private readonly ILicorService _licorService;
    private readonly IMapper _mapper;

    public LicorController(ILicorService LicorService, IMapper mapper)
    {
        _licorService = LicorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<LicorResource>> GetAllAsync()
    {
        var licor = await _licorService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Licor>, IEnumerable<LicorResource>>(licor);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveLicorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var licor = _mapper.Map<SaveLicorResource, Licor>(resource);
        var result = await _licorService.SaveAsync(licor);

        if (!result.Success)
            return BadRequest(result.Message);

        var licorResource = _mapper.Map<Licor, LicorResource>(result.Resource);

        return Ok(licorResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLicorResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var licor = _mapper.Map<SaveLicorResource, Licor>(resource);
        var result = await _licorService.UpdateAsync(id, licor);

        if (!result.Success)
            return BadRequest(result.Message);


        var licorResource = _mapper.Map<Licor, LicorResource>(result.Resource);
        return Ok(licorResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _licorService.DeleteAsync(id);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var licorResource = _mapper.Map<Licor, LicorResource>(result.Resource);
        return Ok(licorResource);
    }

}

