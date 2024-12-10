using LoginRegistration.Models;
using LoginRegistration.Repository;
using LoginRegistration.ViewModel;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LoginRegistration.Controllers
{
    public class AccountUserController : Controller
    {
        private readonly IRegistraionRepo _userservices;
        private readonly UserManager<UserAccount> _userManager;
        private readonly SignInManager<UserAccount> _signIn;

        public AccountUserController(IRegistraionRepo Userservices, SignInManager<UserAccount> SignIn,UserManager<UserAccount> userManager)
        {
            _userservices = Userservices;
            _signIn = SignIn;
            _userManager = userManager;
        }
        //[AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied");
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInVM user)
        {
            if(ModelState.IsValid)
            {
                //check
                UserAccount account = await _userManager.FindByNameAsync(user.UserName);
                if(account!=null)
                {
                    bool found = await _userManager.CheckPasswordAsync(account, user.Password);
                    if(found)
                    {
                        await _signIn.SignInAsync(account, user.RememberMe);
                        return RedirectToAction("Index");
                    }
                }
                ModelState.AddModelError("", "User name or Password invalid");
            }
            return View(user);
            
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationUserModel newUser)
        {
            UserAccount userAccount = _userservices.RegisterUser(newUser);

            if (!ModelState.IsValid)
            {
                return View(newUser);
            }
            var result = await _userManager.CreateAsync(userAccount, newUser.Password);
            if (result.Succeeded)
            {
                await _signIn.SignInAsync(userAccount, false);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(newUser);
            }
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> SignOut()
        {
            await _signIn.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}
