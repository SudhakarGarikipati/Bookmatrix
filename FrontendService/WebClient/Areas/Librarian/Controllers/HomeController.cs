using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.Librarian.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
