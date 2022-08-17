using AutoMapper;
using Candor.Domain.Models;
using Candor.Web.ViewModels.Authorization;

namespace Candor.Web.MappingProfiles;

/// <summary>
/// User mapping profile.
/// </summary>
public class UserMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public UserMappingProfile()
    {
        CreateMap<RegistrationViewModel, User>();
    }
}
