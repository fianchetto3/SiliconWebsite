using System.ComponentModel.DataAnnotations;

namespace SiliconWebbApp.Models.Form;

public class SignUpModel
{
    [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
    [Required(ErrorMessage = "Invalid First name")]
    public string FirstName { get; set; } = null!;



    [Display(Name = "Last Name", Prompt = "Enter your Last name", Order = 1)]
    [Required(ErrorMessage = "Invalid Last name")]
    public string LastName { get; set; } = null!;



    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email", Prompt = "Enter your Email", Order = 2)]
    [Required(ErrorMessage = "Invalid Email")]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$ ", ErrorMessage = "Invalid Email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password", Prompt = "Enter your Password", Order = 3)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Invalid Password")]
    [RegularExpression("^(?=.*[a-zA-Z])(?=.*\\d).{8,}$" , ErrorMessage ="Invalid Password")]
    public string Password { get; set; } = null!;



    [Display(Name = "Confirm Password", Prompt = "Confirm your password", Order = 4)]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password must be confirmed")]
    [Compare(nameof(Password), ErrorMessage ="Password does not match" )]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "I agree to the Terms & Conditions", Prompt = "Enter your first name", Order = 5)]
    [CheckBoxRequired(ErrorMessage = "You must accept Terms & Conditions." )]
    public bool TermsAndCondition { get; set; } = false;



}
public class CheckBoxRequired : ValidationAttribute 
{
    public override bool IsValid(object? value)
    {
        return value is bool b && b;
    }

}
