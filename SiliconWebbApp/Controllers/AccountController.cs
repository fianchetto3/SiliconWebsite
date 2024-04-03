
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiliconInfrastructure.Entities;
using SiliconWebbApp.Models.Views;

namespace SiliconWebbApp.Controllers
{
    public class AccountController(UserManager<UserEntity> userManager) : Controller
    {
        private readonly UserManager<UserEntity> _userManager = userManager;

        [Route("/account/details")]
        public IActionResult Details() 
        {
            var viewModel = new AccountDetailsViewModel();
            
            return View(viewModel);
            
        }

        [HttpPost]
        public IActionResult BasicInfo(AccountDetailsViewModel viewModel)
        {
            if(TryValidateModel(viewModel.BasicInfo))
            {
                return RedirectToAction("Home", "Index");
            }
            return View("Details", viewModel);

           
            
        }

        [HttpPost]
        public IActionResult AddressInfo(AccountDetailsViewModel viewModel)
        {
            if (TryValidateModel(viewModel.AddressInfo))
            {
                return RedirectToAction("Home", "Index");
            }
            return View("Details", viewModel);


        }

    }
}
