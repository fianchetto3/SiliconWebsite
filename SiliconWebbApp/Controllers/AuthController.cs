using Microsoft.AspNetCore.Mvc;

namespace SiliconWebbApp.Controllers;

public class AuthController : Controller
{
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }
}
