using Infrastructure.Entities;
using Infrastructure.Model;
using SiliconWebbApp.Models.Account;

namespace SiliconWebbApp.Models.Views;

public class AccountDetailsViewModel
{

    public string Title { get; set; } = "Account Details";

    public AccountDetailsBasicInfo BasicInfo { get; set; } = new AccountDetailsBasicInfo()
    {
        ProfileImage = "/images/john-doe.svg",
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com"

    };


    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();


}
