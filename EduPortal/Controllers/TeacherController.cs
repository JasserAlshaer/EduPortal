using EduPortal.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
          
            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();
            var login = _context.Login.ToList();
            var user = _context.Teacher.Where(x => x.TeacherId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            var profile = from s in spectilization
                          join u in user on s.SpectializationId equals u.SpectializationId
                          join l in login on u.TeacherId equals l.TeacherId

                          select new profileTeacher
                          {
                              Spectialization = s,
                              Login=l,
                              Teacher = u
                          };
            return View(profile);
        }

        public IActionResult Sessions()
        {
            var session = _context.Session.Where(s => s.TeacherId == HttpContext.Session.GetInt32("Id")).ToList();
            var course =_context.Course.ToList();

            var join = from c in course
                       join s in session on c.CourseId equals s.CourseId
                       select new TeacherSession
                       {
                           Session=s,
                           Course=c,
                       };
            return View(join);
        }

        public IActionResult SessionInformationShow()
        {
            int id = 1;
            ViewBag.Metting = _context.Metting.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Matierial = _context.Material.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Task = _context.Task.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Chat = _context.ChatGroup.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            //ViewBag.Exams= _context.Exam.Where(x => x.Course == id).DefaultIfEmpty().ToList();
            var students = _context.Student.DefaultIfEmpty().ToList();
            var session = _context.Session.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            var Mysession = _context.StudentsSession.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();

            var thisSessionStudent = from std in students
                                     join ms in Mysession
                on std.StudentId equals ms.StudentId
                                     join s in session on ms.SessionId equals s.SessionId
                                     select new SessionAvailableStudents
                                     {
                                         Session=s,
                                         StudentsSession=ms,
                                         Student=std
                                     };
            ViewBag.myStudent=thisSessionStudent;


            var course = _context.Course.DefaultIfEmpty().ToList();
            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();
            var time = _context.Schedule.DefaultIfEmpty().ToList();
            var teach = _context.Teacher.DefaultIfEmpty().ToList();
            var innerJoinForRegisteredCourses = from s in spectilization
                                                join c in course on s.SpectializationId equals c.SpectializationId
                                                join ses in session on c.CourseId equals ses.CourseId
                                               
                                                join myt in time on ses.ScheduleId equals myt.ScheduleId
                                                join t in teach on ses.TeacherId equals t.TeacherId
                                              
                                                select new RegisteredSession
                                                {
                                                    Spectialization = s,
                                                    Course = c,
                                                    Session = ses,
                                                    Schedule = myt,
                                                    Teacher = t
                                                };
           
            return View (innerJoinForRegisteredCourses.ElementAt(0));
        }

       

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(IFormFile image , string name ,string phone ,string pio)
        {


            var record = _context.Teacher.Where(x => x.TeacherId == HttpContext.Session.GetInt32("Id")).SingleOrDefault();
            if(record == null)
            {
                return RedirectToAction("Profie");
            }
            else
            {
                if(image == null)
                {
                    record.FullName = name;
                    record.PhoneNumber = phone;
                    record.Pio = pio;
                    _context.Update(record);
                    _context.SaveChanges();
                }
                else
                {
                    String wRootPath = _env.WebRootPath;
                    String fileName = Guid.NewGuid().ToString() + "_" + image.FileName;

                    var path1 = Path.Combine(wRootPath + "/Uploads", fileName);

                    using (var filestream = new FileStream(path1, FileMode.Create))
                    {
                        await image.CopyToAsync(filestream);
                    }
                    record.FullName = name;
                    record.PhoneNumber = phone;
                    record.Pio = pio;
                    record.Image = fileName;
                    _context.Update(record);
                    _context.SaveChanges();
                }
                return RedirectToAction("Profie");
            }
        }


        //byModal
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

        //byModal
        [HttpPost]
        public async Task<IActionResult> InsertMatierial(string title,string desc, IFormFile path)
        {
            if (path != null)
            {
                String wRootPath = _env.WebRootPath;
                String fileName = Guid.NewGuid().ToString() + "_" + path.FileName;

                var path1 = Path.Combine(wRootPath + "/Uploads", fileName);

                using (var filestream = new FileStream(path1, FileMode.Create))
                {
                    await path.CopyToAsync(filestream);
                }

                Material m=new Material();
                m.Title = title;
                m.Description = desc;
                m.FilePath = path1;




                _context.Add(m);
                _context.SaveChanges();
            }
               
            return RedirectToAction("QuestionDetails");
        }

        //public IActionResult DeleteTask(int id)
        //{
        //    var rec=_context.Task.wh
        //    return RedirectToAction("SessionInformationShow");
        //}

        public IActionResult GetTaskAnswer(int id)
        {
            var task=_context.Task.Where(x => x.TaskId == id).ToList();
            var std=_context.Student.ToList();
            var stdTask=_context.StudentTask.Where(x => x.TaskId == id).ToList();



            var join = from t in task
                       join st in stdTask
                       on t.TaskId equals st.TaskId
                       join s in std on st.StudentId equals s.StudentId
                       select new TaskAnswers
                       {
                           Student=s,
                           Task=t,
                           StudentTask=st
                       };
            return View(join);
        }

        public IActionResult ViewAnswerAndInsertMark(int id)
        {
            var stdTask = _context.StudentTask.Where(x => x.TaskId == id).SingleOrDefault();
            if (stdTask != null)
            {
                return View(stdTask);
            }
            return Unauthorized();
        }


        [HttpPost]
        public IActionResult InsertMarks(int id, int mark,string note)
        {

            var stdTask = _context.StudentTask.Where(x => x.TaskId == id).SingleOrDefault();
            if (stdTask != null)
            {
                stdTask.ActualMark = mark;
                stdTask.FinalResult = mark;
                stdTask.TeacherResponse = note;

                _context.Update(stdTask);
                _context.SaveChanges();
            }


            return RedirectToAction("SessionInformationShow");


        }


            //byModal
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
        //byModal
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
                task.Weight = mark;
                task.FilePath = fileName;
                task.SessionId = sessionId;
                if (lastdate != null)
                {
                    task.IsAllowLateSubmmition = true;
                    task.LastAllowedSubmmation = lastdate;
                }
              
                task.StartAt = start;
                task.EndAt = end;   
              

                _context.Add(task);
                _context.SaveChanges();


            }
           
            return RedirectToAction("SessionInformationShow");
        }
        //byModal
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

        //public IActionResult UpdateToDo(int id )
        //{
        //    var item = _context.ToDoList.Where(x => x.ToDoListId == id).First();
        //    if (item != null)
        //    {
        //        return View(item);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
        //byModal
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

        public IActionResult UsersMassages()
        {
            return View();
        }

        public IActionResult GetMassagesInChatGroup()
        {
            return View();
        }
        [HttpPost]
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
