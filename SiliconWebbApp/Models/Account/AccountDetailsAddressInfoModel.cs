using System.ComponentModel.DataAnnotations;

namespace SiliconWebbApp.Models.Account;

public class AccountDetailsAddressInfoModel
{
    [Display(Name = "Address 1", Prompt = "Enter your Address line", Order = 0)]
    [Required(ErrorMessage = "Invalid Address")]
    
    public string Addressline_1 { get; set; } = null!;



    [Display(Name = "Address 2", Prompt = "Enter your second address line", Order = 1)]
    public string? Addressline_2 { get; set; } 


    [Display(Name = "Postal code", Prompt = "Enter your postal code", Order = 2)]
    [Required(ErrorMessage = "Postal code is required")]
    [DataType(DataType.PostalCode)]
    public string PostalCode { get; set; } = null!;



    [Display(Name = "City", Prompt = "Enter your City", Order = 3)]
    [Required(ErrorMessage = "City is required")]
    public string City { get; set; } = null!;
}
