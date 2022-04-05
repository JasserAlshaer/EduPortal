using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
