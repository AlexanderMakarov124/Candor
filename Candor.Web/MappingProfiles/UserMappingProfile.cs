using AutoMapper;
using Candor.Domain.Models;
using Candor.Web.ViewModels;

namespace Candor.Web.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<RegistrationViewModel, User>();
    }
}
