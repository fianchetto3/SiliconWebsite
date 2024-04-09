using SiliconWebbApp.Models.Account;

namespace SiliconWebbApp.Models.Views;

public class AccountDetailsViewModel
{

    public string Title { get; set; } = "Account Details";

    public ProfileInfoViewModel ProfileInfo { get; set; } = null!;

    public AccountDetailsBasicInfo BasicInfo { get; set; } = null!;

    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = null!;


}
