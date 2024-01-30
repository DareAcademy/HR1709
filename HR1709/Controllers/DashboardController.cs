using Microsoft.AspNetCore.Mvc;

namespace HR1709.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
