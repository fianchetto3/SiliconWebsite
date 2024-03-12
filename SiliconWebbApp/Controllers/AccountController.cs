using Microsoft.AspNetCore.Mvc;
using SiliconWebbApp.Models.Views;

namespace SiliconWebbApp.Controllers
{
    public class AccountController : Controller
    {

        [Route("/account")]
        public IActionResult Details() 
        {
            var viewModel = new AccountDetailsViewModel();
            //viewModel.BasicInfo = _accountservice.GetBasicInfo();
            //viewModel.AddressInfo = _accountService.GetAddressInfo();
            return View(viewModel);
            
        }

        [HttpPost]
        public IActionResult BasicInfo(AccountDetailsViewModel viewModel)
        {
           //_accountService.SaveBasicInfo(viewModel.BasicInfo)
            return RedirectToAction(nameof(Details), viewModel);
        }

        [HttpPost]
        public IActionResult AddressInfo(AccountDetailsViewModel viewModel)
        {
            //_accountService.SaveAddressInfo(viewModel.AddressInfo)
            return RedirectToAction(nameof(Details), viewModel);
        }

    }
}
