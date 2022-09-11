using Candor.Domain.Models;
using MediatR;

namespace Candor.UseCases.Blog.Comments.FindCommentById;

/// <summary>
/// Find comment by id query.
/// </summary>
/// <param name="Id">Comment id.</param>
public record FindCommentByIdQuery(int Id) : IRequest<Comment>;
