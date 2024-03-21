using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Incorrect Password or Email.")]
        public string? ErrorMessage { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Enter your Email", Order = 0)]
        [Required(ErrorMessage = "Email does not match or doesn't exist")]

        public string Email { get; set; } = null!;

        [Display(Name = "Password", Prompt = "Enter your Password", Order = 1)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = " ")]

        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me", Order = 2)]
        public bool RememberMe { get; set; }
    }
}
