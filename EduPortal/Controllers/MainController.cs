using EduPortal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EduPortal.Controllers
{
    public class MainController : Controller
    {
        private readonly EduPortalContext _context;
        private readonly IWebHostEnvironment _env;

        public MainController(EduPortalContext _context, IWebHostEnvironment _env)
        {
            this._context = _context;
            this._env = _env;
        }

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
        [HttpPost]
        public IActionResult Login(string email,string password)
        {

            var auth = _context.Login.Where(x => x.Email == email && x.Password == password).SingleOrDefault();
            if (auth != null)
            {

                if (auth.TeacherId != null)
                {
                   
                    HttpContext.Session.SetInt32("Id", (int)auth.TeacherId);
                    return RedirectToAction("Index", "Teacher");
                    
                }
                else
                {
                    
                    HttpContext.Session.SetInt32("Id", (int)auth.StudentId);
                    return RedirectToAction("Index", "Students");

                }
                  

            }
            return NotFound();

        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
