using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCTestApp.Models;

namespace MVCTestApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("LoginUser");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Customers");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUser registerUser)
        {
            if (ModelState.IsValid)
            {
                var user=new IdentityUser() { UserName=registerUser.Email, Email=registerUser.Email };

               var result=await _userManager.CreateAsync(user, registerUser.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Customers");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, loginUser.RememberMe, false);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Customers");
                }


                ModelState.AddModelError(string.Empty, "Invalid Login. Please enter the credentials again.");

            }
            return View("LoginUser",loginUser);
        }
    }
}
