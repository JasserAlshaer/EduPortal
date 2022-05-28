using EduPortal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EduPortal.Controllers
{
    public class TeacherController : Controller
    {
        private readonly EduPortalContext _context;
        private readonly IWebHostEnvironment _env;

        public TeacherController(EduPortalContext _context, IWebHostEnvironment _env)
        {
            this._context = _context;
            this._env = _env;
        }
        public IActionResult Index()
        {

            ViewBag.ToDo = _context.ToDoList.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();
            //ViewBag.Tasks = _context.StudentTask.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();
            //ViewBag.Exams = _context.StudentTakeExam.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();
            //ViewBag.Attend = _context.StudentAttendanceRecord.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();
            //.Matierial = _context.StudentsFinishMaterial.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();
            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();

            var user = _context.Teacher.Where(x => x.TeacherId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            var profile = from s in spectilization
                          join u in user on s.SpectializationId equals u.SpectializationId


                          select new profileTeacher
                          {
                              Spectialization = s,

                              Teacher = u
                          };
            return View(profile);
        }

        public IActionResult Sessions()
        {
            return View();
        }

        public IActionResult SessionInfo(int id)
        {
            ViewBag.Metting = _context.Metting.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Matierial = _context.Material.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Task = _context.Task.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Chat = _context.ChatGroup.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            //ViewBag.Attendance = _context.StudentAttendanceRecord.Where(x => x.SessionId == id && x.StudentId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();


            var course = _context.Course.DefaultIfEmpty().ToList();
            var students = _context.Student.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            var session = _context.Session.DefaultIfEmpty().ToList();
            var Mysession = _context.StudentsSession.DefaultIfEmpty().ToList();
            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();
            var time = _context.Schedule.DefaultIfEmpty().ToList();
            var teach = _context.Teacher.DefaultIfEmpty().ToList();
            var innerJoinForRegisteredCourses = from s in spectilization
                                                join c in course on s.SpectializationId equals c.SpectializationId
                                                join ses in session on c.CourseId equals ses.CourseId
                                                join myses in Mysession on ses.SessionId equals myses.SessionId
                                                join myt in time on ses.ScheduleId equals myt.ScheduleId
                                                join t in teach on ses.TeacherId equals t.TeacherId
                                                join std in students on myses.StudentId equals std.StudentId
                                                select new RegisteredSession
                                                {
                                                    Spectialization = s,
                                                    Course = c,
                                                    Session = ses,
                                                    StudentsSession = myses,
                                                    Student = std,
                                                    Schedule = myt,
                                                    Teacher = t
                                                };
            return View(innerJoinForRegisteredCourses);
        }

        public IActionResult Profile()
        {
            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();
           
            var user = _context.Teacher.Where(x => x.TeacherId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            var profile = from s in spectilization
                          join u in user on s.SpectializationId equals u.SpectializationId
                        

                          select new profileTeacher
                          {
                              Spectialization = s,
                            
                              Teacher = u
                          };
            return View(profile);
        }

        public IActionResult QuestionBank(int id)
        {
            return View(_context.Question.Where(x=> x.CourseId==id).ToList());
        }

        public IActionResult QuestionDetails(int id)
        {
            ViewBag.Options = _context.Option.Where(x => x.QuestionId == id).DefaultIfEmpty().ToList();
            return View(_context.Question.Where(x => x.CourseId == id).ToList());
        }

        public IActionResult InsertQuestion()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult InsertQuestion(string title)
        {
            //Insert options and Question
            return View();
        }

        public IActionResult InsertTask()
        {

            return View();
        }
        [HttpPost]
        public IActionResult InsertTask(string title)
        {
            //Insert options and Question
            return View();
        }
        public IActionResult AddToDo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToDo(string title)
        {
            return View();
        }
        public IActionResult DeleteToDo()
        {
            return View();
        }
        public IActionResult UpdateToDo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateToDo(int id)
        {
            return View();
        }

        public IActionResult UsersMassages()
        {
            return View();
        }

        public IActionResult GetMassagesInChatGroup()
        {
            return View();
        }

        public IActionResult SendMassages()
        {
            return View();
        }
        public IActionResult Calender()
        {
            ViewBag.ToDo = _context.ToDoList.Where(x => x.TeacherId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            return View();
        }
        public IActionResult ToDoList()
        {
            return View(_context.ToDoList.Where(x => x.TeacherId == HttpContext.Session.GetInt32("Id")).ToList());
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
