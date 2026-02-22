using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
