using Microsoft.AspNetCore.Mvc;

namespace EduPortal.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
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

        public IActionResult QuestionBank()
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
        public IActionResult Logout()
        {
            return View();
        }
    }
}
