using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
