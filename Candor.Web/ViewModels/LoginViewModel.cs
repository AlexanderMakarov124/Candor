using System.ComponentModel.DataAnnotations;

namespace Candor.Web.ViewModels;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Username")]
    [MaxLength(30)]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
