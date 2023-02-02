using AutoMapper;
using Kampai.Licors.Domain.Model;
using Kampai.Licors.Resources;

namespace Kampai.Licors.Mapping;

public class ResourceToModelLicorProfile: Profile
{
    public ResourceToModelLicorProfile()
    {
        CreateMap<SaveLicorResource, Licor>();
    }
}