using System.ComponentModel.DataAnnotations;

namespace Candor.Web.ViewModels.Authorization;

/// <summary>
/// Registration view model.
/// </summary>
public class RegistrationViewModel
{
    /// <summary>
    /// User name.
    /// </summary>
    [Required]
    [Display(Name = "Username")]
    [MaxLength(30)]
    [MinLength(3, ErrorMessage = "Username must contain at least 3 characters.")]
    public string? UserName { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    [Required]
    [Display(Name = "Name")]
    public string? Name { get; set; }

    /// <summary>
    /// Email.
    /// </summary>
    [Required]
    [Display(Name = "Email")]
    public string? Email { get; set; }

    /// <summary>
    /// Password.
    /// </summary>
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string? Password { get; set; }
}
