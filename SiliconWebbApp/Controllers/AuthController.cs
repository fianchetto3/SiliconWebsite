using Microsoft.AspNetCore.Mvc;

namespace SiliconWebbApp.Controllers;

public class AuthController : Controller
{
    public IActionResult SignUp()
    {
        return View();
    }
}
