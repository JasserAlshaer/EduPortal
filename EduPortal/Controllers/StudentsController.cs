using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Sessions()
        {
            return View();
        }

        public IActionResult SessionInfo()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Calender()
        {
            return View();
        }
        public IActionResult ToDoList()
        {
            return View();
        }
        public IActionResult Marks()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
