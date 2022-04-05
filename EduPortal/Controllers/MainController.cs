using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
