using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.FindPostById;

/// <summary>
/// Find post by id query.
/// </summary>
/// <param name="Id">Post id.</param>
public record FindPostByIdQuery(int Id) : IRequest<Post>;
