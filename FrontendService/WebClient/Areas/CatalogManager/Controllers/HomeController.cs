using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.CatalogManager.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
