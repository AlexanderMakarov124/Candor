namespace Candor.Infrastructure.Common;

/// <summary>
/// Not found exception.
/// </summary>
public class NotFoundException : Exception
{
    /// <summary>
    /// Initialize the exception.
    /// </summary>
    public NotFoundException()
    {
    }

    /// <summary>
    /// Initialize the exception with a message.
    /// </summary>
    /// <param name="message">Message that describes the exception.</param>
    public NotFoundException(string message) : base(message)
    {
    }
}
