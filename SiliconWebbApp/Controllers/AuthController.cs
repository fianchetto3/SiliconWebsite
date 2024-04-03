using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconInfrastructure.Entities;
using SiliconWebbApp.Models.Views;
using System.Security.Claims;

namespace SiliconWebbApp.Controllers;

public class AuthController : Controller
{
    private readonly UserManager<UserEntity> _userManager;

    public AuthController(UserManager<UserEntity> userManager)
    {
        _userManager = userManager;
    }

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
            var exsist = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Form.Email);
            if (exsist)
            {
                ViewData["ErrorMessage"] = "User with Same Email Exsists";
                return View(viewModel);
            }

            var userEntity = new UserEntity
            {
                FirstName = viewModel.Form.FirstName,
                LastName = viewModel.Form.LastName,
                Email = viewModel.Form.Email,
                UserName = viewModel.Form.Email,
                Bio = viewModel.Form.Bio 

            };

            var result =  await _userManager.CreateAsync(userEntity, viewModel.Form.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Index");
            }


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

            return View(viewModel);
    }

    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
       await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }



}
