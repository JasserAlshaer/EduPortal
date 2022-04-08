using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Contactus()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Spectilizations()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
