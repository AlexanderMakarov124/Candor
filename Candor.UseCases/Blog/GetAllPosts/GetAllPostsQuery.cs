using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.GetAllPosts;

/// <summary>
/// Get all posts query.
/// </summary>
public record GetAllPostsQuery : IRequest<IEnumerable<Post>>;