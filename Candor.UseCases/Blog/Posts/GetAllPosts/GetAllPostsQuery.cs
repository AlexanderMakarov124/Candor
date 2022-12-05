using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.Posts.GetAllPosts;

/// <summary>
/// Get all posts query.
/// </summary>
public record GetAllPostsQuery : IRequest<IQueryable<Post>>;