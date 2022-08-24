using System.ComponentModel.DataAnnotations;

namespace Candor.Web.ViewModels.Authorization;

/// <summary>
/// Login view model.
/// </summary>
public class LoginViewModel
{
    /// <summary>
    /// User name.
    /// </summary>
    [Required]
    [Display(Name = "Username")]
    [MaxLength(30)]
    public string? UserName { get; set; }

    /// <summary>
    /// Password.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
}
