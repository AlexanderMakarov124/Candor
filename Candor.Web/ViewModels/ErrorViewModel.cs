namespace Candor.Web.ViewModels;

/// <summary>
/// Error view model.
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Request id.
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Indicates to show request id.
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
