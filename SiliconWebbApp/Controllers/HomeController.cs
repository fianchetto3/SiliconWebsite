using Microsoft.AspNetCore.Mvc;
using SiliconWebbApp.Models.Compontents;
using SiliconWebbApp.Models.Sections;
using SiliconWebbApp.Models.Views;

namespace SiliconWebbApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        
        var viewModel = new HomeIndexViewModel
        {
            Title = "Home - Silicon",
            Showcase = new ShowcaseViewModel
            {
                Title = "Task Management Assistant You Gonna Love",
                Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
                BrandText = "Largest companies use our tool to work efficiently",
                Id = "showcase",
                Brands =
                [
                    new() {ImageUrl = "/images/brand-names/brand-1.svg", AltText = "Brand Logo Name 1" },
                     new() {ImageUrl = "/images/brand-names/brand-2.svg", AltText = "Brand Logo Name 2" },
                      new() {ImageUrl = "/images/brand-names/brand-3.svg", AltText = "Brand Logo Name 3" },
                       new() {ImageUrl = "/images/brand-names/brand-4.svg", AltText = "Brand Logo Name 4" },
                ],

                Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get Started for free" },
                ShowcaseImage = new () { ImageUrl = "/images/dashbord-image.svg", AltText ="dashbord image"  },

            }
        };
        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
