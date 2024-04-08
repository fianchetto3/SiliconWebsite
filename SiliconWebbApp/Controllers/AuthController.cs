using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconInfrastructure.Entities;
using SiliconWebbApp.Models.Views;
using System.Security.Claims;

namespace SiliconWebbApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Details", "Account");
        }
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
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Details", "Account");
        }
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, viewModel.Form.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Details", "Account");
            }

        }
        


            return View(viewModel);
    }

    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }



}
