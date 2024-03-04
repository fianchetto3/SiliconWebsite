using Microsoft.AspNetCore.Mvc;
using SiliconWebbApp.Models.Views;

namespace SiliconWebbApp.Controllers;

public class AuthController : Controller
{
    [Route("/signup")]
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }
}
