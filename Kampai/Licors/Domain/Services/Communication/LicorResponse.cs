using Kampai.Licors.Domain.Model;
using Kampai.Shared.Domain.Services.Communication;

namespace Kampai.Licors.Domain.Repositories.Communication;

public class LicorResponse : BaseResponse<Licor>
{
    public LicorResponse(Licor resource) : base(resource)
    {
    }

    public LicorResponse(string message) : base(message)
    {
    }
}