using EduPortal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
            return View(_context.Session.Where(s=>s.TeacherId== HttpContext.Session.GetInt32("Id")).ToList());
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
            ViewBag.Options = _context.Option.DefaultIfEmpty().ToList();
            return View(_context.Question.Where(x => x.CourseId == id).ToList());
        }

        public IActionResult InsertQuestion()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult InsertQuestion(string title,int courseId,bool multipleAnswers,int typeId)
            
        {
            //Insert options and Question
            Question question = new Question();
            question.CourseId = courseId;
            question.Text= title;
            question.IsHaveMultipleCorrectAnswer = multipleAnswers;
            question.QuestionTypeId = typeId;
            question.TeacherId = HttpContext.Session.GetInt32("Id");
            question.IsActive = true;
            _context.Add(question);
            _context.SaveChanges();



            return RedirectToAction("QuestionDetails");
        }

        public IActionResult InsertOption()
        {
            return View();
        }
        [HttpPost]
        public IActionResult InsertOption(string answer,bool iscorrect)
        {
            Option option = new Option();
            option.QuestionId = _context.Question.OrderByDescending(x => x.QuestionId).First().QuestionId;
            option.Answer = answer;
            option.IsCorrect = iscorrect;
            _context.Add(option);
            _context.SaveChanges();
            return RedirectToAction("QuestionDetails");
        }
        public IActionResult InsertTask()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertTask(string title,string note,int mark,int weight,IFormFile taskFile
            ,int sessionId,bool lastSubmit,DateTime start, DateTime end, DateTime lastdate)
        {
            if (taskFile != null)
            {
                String wRootPath = _env.WebRootPath;
                String fileName = Guid.NewGuid().ToString() + "_" + taskFile.FileName;

                var path1 = Path.Combine(wRootPath + "/Uploads", fileName);

                using (var filestream = new FileStream(path1, FileMode.Create))
                {
                    await taskFile.CopyToAsync(filestream);
                }
                Models.Task task = new Models.Task();
                task.Title = title;
                task.Note = note;
                task.Mark = mark;
                task.Weight = weight;
                task.FilePath = fileName;
                task.SessionId = sessionId;
                task.IsAllowLateSubmmition = lastSubmit;
                task.StartAt = start;
                task.EndAt = end;   
                task.LastAllowedSubmmation = lastdate;

                _context.Add(task);
                _context.SaveChanges();


            }
           
            return View();
        }
        public IActionResult AddToDo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToDo(string title,string desc,bool isdone,DateTime start,DateTime end
            ,int priority)
        {
            ToDoList doList= new ToDoList();

            doList.TaskTitle = title;
            doList.Description = desc;
            doList.IsDone = isdone;
            doList.StartAt = start;
            doList.DoneAt = end;
            doList.Priority = priority;
            doList.StudentId = null;
            doList.TeacherId = HttpContext.Session.GetInt32("Id");
             _context.Add(doList);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult DeleteToDo(int id)
        {
            var item=_context.ToDoList.Where(x=>x.ToDoListId==id).First();
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
           
        }
        public IActionResult UpdateToDo(int id )
        {
            var item = _context.ToDoList.Where(x => x.ToDoListId == id).First();
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult UpdateToDo(int id,string title, string desc, bool isdone, DateTime start, DateTime end
            , int priority)
        {
            var doList = _context.ToDoList.Where(x => x.ToDoListId == id).First();
            if (doList != null)
            {
                doList.TaskTitle = title;
                doList.Description = desc;
                doList.IsDone = isdone;
                doList.StartAt = start;
                doList.DoneAt = end;
                doList.Priority = priority;
                doList.StudentId = null;
                doList.TeacherId = HttpContext.Session.GetInt32("Id");
                _context.Add(doList);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
           

           
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
