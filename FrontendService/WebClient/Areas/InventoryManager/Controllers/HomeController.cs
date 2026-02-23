using Microsoft.AspNetCore.Mvc;

namespace WebClient.Areas.InventoryManager.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
