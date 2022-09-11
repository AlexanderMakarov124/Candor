using AutoMapper;
using Candor.Domain.Models;
using Candor.UseCases.Blog.Comments.CreateComment;

namespace Candor.Web.MappingProfiles;

/// <summary>
/// Comment mapping profile.
/// </summary>
public class CommentMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public CommentMappingProfile()
    {
        CreateMap<CreateCommentCommand, Comment>()
            .ForMember(destination => destination.CreatedAt, options => options.MapFrom(date => DateTime.UtcNow));
    }
}
