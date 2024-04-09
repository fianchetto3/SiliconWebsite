
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconInfrastructure.Context;
using SiliconInfrastructure.Entities;
using SiliconInfrastructure.Services;
using SiliconWebbApp.Models.Account;
using SiliconWebbApp.Models.Views;
using System.Security.Claims;

namespace SiliconWebbApp.Controllers;

[Authorize]
public class AccountController(UserManager<UserEntity> userManager, AppDbContext context, AddressManager addressManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly AppDbContext _context = context;
    private readonly AddressManager _addressManager = addressManager;



    [HttpGet]
    [Route("/account/details")]
    public async Task<IActionResult> Details()
    {
        var viewModel = new AccountDetailsViewModel
        {
            ProfileInfo = await PopulateProfileInfoAsync()
        };
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();



        return View(viewModel);

    }

    #region[HttpPost] Details
    [HttpPost]
    [Route("/account/details")]
    public async Task<IActionResult> Details(AccountDetailsViewModel viewModel)
    {
        if (viewModel.BasicInfo != null)
        {
            if (
                viewModel.BasicInfo.FirstName != null &&
                viewModel.BasicInfo.LastName != null &&
                viewModel.BasicInfo.Email != null
                )


            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    user.FirstName = viewModel.BasicInfo.FirstName;
                    user.LastName = viewModel.BasicInfo.LastName;
                    user.Email = viewModel.BasicInfo.Email;
                    user.PhoneNumber = viewModel.BasicInfo.Phone;
                    user.Bio = viewModel.BasicInfo.Biography!;

                    await _userManager.UpdateAsync(user);


                }
            }


        }
        // 1:27:27
        if (viewModel.AddressInfo != null)
        {
            if (
                viewModel.AddressInfo.Addressline_1 != null &&
                viewModel.AddressInfo.PostalCode != null &&
                viewModel.AddressInfo.City != null
                )


            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var address = await _addressManager.GetAddressAsync(user.Id);
                    if (address != null) {

                        address.StreetName = viewModel.AddressInfo.Addressline_1;
                        address.City = viewModel.AddressInfo.City;
                        address.PostalCode = viewModel.AddressInfo.PostalCode;

                        await _addressManager.UpdateAddressAsync(address);
                    }
                    else
                    {
                        address = new AddressEntity
                        {
                          
                            StreetName = viewModel.AddressInfo.Addressline_1,
                            City = viewModel.AddressInfo.City,
                            PostalCode = viewModel.AddressInfo.PostalCode,


                        };
                    }

                  var result = await _addressManager.CreateAddressAsync(address);
                    

                }
            }


        }


        viewModel.ProfileInfo = await PopulateProfileInfoAsync();
        viewModel.BasicInfo ??= await PopulateBasicInfoAsync();
        viewModel.AddressInfo ??= await PopulateAddressInfoAsync();


        return View(viewModel);

    }
    #endregion

    private async Task<ProfileInfoViewModel> PopulateProfileInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);


        return new ProfileInfoViewModel
        {

            FirstName = user!.FirstName,
            LastName = user.LastName,
            Email = user.Email!,

        };

    }

    private async Task<AccountDetailsBasicInfo> PopulateBasicInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);


        return new AccountDetailsBasicInfo
        {
            UserId = user!.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email!,
            Phone = user.PhoneNumber!,
            Biography = user.Bio,
        };

    }
    private async Task<AccountDetailsAddressInfoModel> PopulateAddressInfoAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if(user != null)
        {
           var address = await _addressManager.GetAddressAsync(user.Id);
            if (address == null)
            {
                address = new AddressEntity {
                StreetName = "Default",
                City = "Default",
                PostalCode = "Default",

                };
                await _addressManager.CreateAddressAsync(address);    
                
            }
               
            return new AccountDetailsAddressInfoModel
            {
                Addressline_1 = address.StreetName,
                City = address.City,
                PostalCode = address.PostalCode,
            };

        }
        else
        {
            return new AccountDetailsAddressInfoModel();
        }


        
    }

}


