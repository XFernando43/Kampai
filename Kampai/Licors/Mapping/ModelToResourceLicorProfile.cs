using AutoMapper;
using Kampai.Licors.Domain.Model;
using Kampai.Licors.Resources;

namespace Kampai.Licors.Mapping;

public class ModelToResourceLicorProfile: Profile
{
    public ModelToResourceLicorProfile()
    {
        CreateMap<SaveLicorResource, Licor>();
    }
    
}