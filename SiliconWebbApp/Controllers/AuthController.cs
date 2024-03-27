using Infrastructure.Model;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SiliconWebbApp.Models.Views;
using System.Security.Claims;

namespace SiliconWebbApp.Controllers;

public class AuthController(UserService userService) : Controller
{
    private readonly UserService _userService = userService;

    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [Route("/signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.CreateUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Model.StatusCode.OK)
                return RedirectToAction("SignIn", "Auth");

        }
          
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            var userModel = await _userService.SignInAsync(viewModel.Form);
             if (userModel != null)
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, userModel.Id),
                    new(ClaimTypes.Name, userModel.Email),
                    new(ClaimTypes.Email, userModel.Email),

                };

                await HttpContext.SignInAsync("AuthCookie", new ClaimsPrincipal(new ClaimsIdentity(claims, "AuthCookie")));
                return RedirectToAction("Index", "Account");
            }
                

        }
            return View(viewModel);
    }

    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
       await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Account");
    }



}
