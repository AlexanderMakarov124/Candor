using AutoMapper;
using Candor.Domain.Models;
using Candor.UseCases.Blog.CreatePost;
using Candor.Web.ViewModels.Authorization;
using Candor.Web.ViewModels.Blog;

namespace Candor.Web.MappingProfiles;

/// <summary>
/// Post mapping profile.
/// </summary>
public class PostMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public PostMappingProfile()
    {
        CreateMap<CreatePostCommand, Post>()
            .ForMember(destination => destination.CreatedAt, options => options.MapFrom(date => DateTime.UtcNow));
        CreateMap<EditPostViewModel, Post>();
    }
}
