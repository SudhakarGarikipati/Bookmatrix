using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Guest.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
