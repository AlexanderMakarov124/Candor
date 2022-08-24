namespace Candor.Web.ViewModels;

internal class ErrorViewModel
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
