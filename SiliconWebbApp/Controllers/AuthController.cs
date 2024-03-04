using Microsoft.AspNetCore.Mvc;

namespace SiliconWebbApp.Controllers;

public class AuthController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
