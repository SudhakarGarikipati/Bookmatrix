using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Member.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
