using Administration.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebClient.HttpClients;

namespace WebClient.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthHttpClient _authHttpClient;

        public AccountController(AuthHttpClient authHttpClient)
        {
            _authHttpClient = authHttpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(loginViewModel);
                }
                else
                {
                    var userViewModel = await _authHttpClient.Login(loginViewModel);
                    if (userViewModel?.Roles.Count > 0)
                    {
                        if (userViewModel.Roles[0] == "Admin")
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        return RedirectToAction("Index", "Home", new { area = "Guest" });
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(loginViewModel);
            }
        }
    }
}
