using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
