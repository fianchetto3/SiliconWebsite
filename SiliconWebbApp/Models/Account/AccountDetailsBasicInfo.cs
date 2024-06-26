﻿using System.ComponentModel.DataAnnotations;

namespace SiliconWebbApp.Models.Account
{
    public class AccountDetailsBasicInfo
    {
        public string UserId { get; set; } = null!;


        [Display(Name = "First Name", Prompt = "Enter your first name", Order = 0)]
        [Required(ErrorMessage = "Invalid First name")]
        public string FirstName { get; set; } = null!;



        [Display(Name = "Last Name", Prompt = "Enter your Last name", Order = 1)]
        [Required(ErrorMessage = "Invalid Last name")]
        public string LastName { get; set; } = null!;



        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", Prompt = "Enter your Email", Order = 2)]
        [Required(ErrorMessage = "Invalid Email")]
        [RegularExpression("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; } = null!;


        [Display(Name = "Phone", Prompt = "Enter your Phone", Order = 3)]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Display(Name = "Biography", Prompt = "Add a short bio...", Order = 4)]
        [DataType(DataType.MultilineText)]
        public string? Biography { get; set; }    
    }
}
