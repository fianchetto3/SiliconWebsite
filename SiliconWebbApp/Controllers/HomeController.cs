using Microsoft.AspNetCore.Mvc;

namespace SiliconWebbApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Task Manager";

        return View();
    }
}
