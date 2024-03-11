using System.ComponentModel.DataAnnotations;

namespace SiliconWebbApp.Models.Form;

public class SignInModel
{

    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your Email", Order = 0)]
    [Required(ErrorMessage = "Invalid Email")]
  
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your Password", Order = 1)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Invalid Password")]

    public string Password { get; set; } = null!;

    [Display(Name = "Remember Me", Order = 2)]
     public bool RememberMe { get; set; }

}
