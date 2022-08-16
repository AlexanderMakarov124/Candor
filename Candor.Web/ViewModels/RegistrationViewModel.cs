using System.ComponentModel.DataAnnotations;

namespace Candor.Web.ViewModels;

public class RegistrationViewModel
{
    [Required]
    [Display(Name = "Username")]
    [MaxLength(30)]
    [MinLength(3, ErrorMessage = "Username must contain at least 3 characters.")]
    public string UserName { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
}
