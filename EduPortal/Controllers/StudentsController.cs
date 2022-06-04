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
    public class StudentsController : Controller
    {
        private readonly EduPortalContext _context;
        private readonly IWebHostEnvironment _env;

        public StudentsController(EduPortalContext _context, IWebHostEnvironment _env)
        {
            this._context = _context;
            this._env = _env;
        }
        public static List<Question> currentExam = new List<Question>();
        public static List<Option>   ExamAnswers = new List<Option>();
        //public static List<String> userAnswer = new List<string>();
        public static double  markSummation=0;
        public static double markWeight=0;
        public static int examIndexPointer = 0;



        public async Task<IActionResult> Exam(int id)
        {



            List<Question> questions = _context.Question.Where(recprd => recprd.ExamId == id).ToList();

            currentExam = questions;
            var exam= _context.Exam.Where(x => x.ExamId == id).SingleOrDefault();
            markWeight = (int)exam.Mark / (int)exam.SumOfQuestion;

            StudentTakeExam studentTakeExam = new StudentTakeExam();
            studentTakeExam.ExamId = id;
            studentTakeExam.StartExamAt= DateTime.Now;
            studentTakeExam.StudentId = HttpContext.Session.GetInt32("Id");

            _context.Add(studentTakeExam);
            _context.SaveChanges();


          

            return RedirectToAction("ExamContent");

        }

        public IActionResult ExamContent()
        {
            ViewBag.Index = examIndexPointer;
            ViewBag.Text = "Next";
           
            List<Option> getOption = _context.Option.Where(o => o.QuestionId == currentExam.ElementAt(0).QuestionId).ToList();
            ExamAnswers = getOption;
            ViewBag.ExamAnswers = getOption;    
            return View("Exam", currentExam.ElementAt(0));

        }

        [HttpPost]
        public IActionResult IncreaseExamIndex(int index, string studentAnswer)
        {

            //grading
               foreach (Option option in _context.Option)
            {
                if(option.IsCorrect==true && option.Answer== studentAnswer)
                {
                    markSummation += markWeight;
                }
            }


            ++examIndexPointer;
            List<Option> getOption = _context.Option.Where(o => o.QuestionId == currentExam.ElementAt(examIndexPointer).QuestionId).ToList();
            ViewBag.Index = examIndexPointer;

            if (examIndexPointer == (currentExam.Count() - 2))
            {
                ViewBag.Text = "Submit and Finish";
            }
            ViewBag.Text = "Next";

          
            ExamAnswers = getOption;
            ViewBag.ExamAnswers = getOption;
            return View("Exam", currentExam.ElementAt(examIndexPointer));

        }


        public IActionResult SubmitExam(string studentAnswer)
        {
            foreach (Option option in _context.Option)
            {
                if (option.IsCorrect == true && option.Answer == studentAnswer)
                {
                    markSummation += markWeight;
                }
            }
            var record = _context.StudentTakeExam.Where(x => x.ExamId == currentExam.ElementAt(0).ExamId
              && x.StudentId == HttpContext.Session.GetInt32("Id")).SingleOrDefault();


            if(record != null)
            {
                record.ActualMark=markSummation;
                record.FinalResult = markSummation;
                record.EndExamAt = DateTime.Now;

                _context.Update(record);
                _context.SaveChanges();
            }


            return RedirectToAction("SessionInfo", HttpContext.Session.GetInt32("CurrecntSession"));


        

        }
        public IActionResult Index()
        {

      
            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();
            var login = _context.Login.ToList();
            var status=_context.Status.ToList();
            var user = _context.Student.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            var profile = from s in spectilization
                          join u in user on s.SpectializationId equals u.SpectializationId
                          join l in login on u.StudentId equals l.StudentId
                          join st in status on u.StatusId equals st.StatusId

                          select new ProfileStudents
                          {
                              Spectialization = s,
                              Login = l,
                              Student = u,
                              Status=st
                          };
            return View(profile.ElementAt(0));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(IFormFile image, string name, string phone, string pio)
        {


            var record = _context.Student.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).SingleOrDefault();
            if (record == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (image == null)
                {
                    record.FullName = name;
                    record.PhoneNumber = phone;
                    //record.Pio = pio;
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
                    //record.Pio = pio;
                    record.Image = fileName;
                    _context.Update(record);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        public IActionResult Sessions()
        {
            var course = _context.Course.DefaultIfEmpty().ToList();
            var students = _context.Student.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            var session = _context.Session.DefaultIfEmpty().ToList();
            var Mysession = _context.StudentsSession.DefaultIfEmpty().ToList();
            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();
            var time = _context.Schedule.DefaultIfEmpty().ToList();
            var teach= _context.Teacher.DefaultIfEmpty().ToList();
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
                                                  
                                                    Schedule=myt,
                                                    Teacher=t
                                                };
            return View(innerJoinForRegisteredCourses);
        }

        public IActionResult SessionInfo(int id)
        {

            HttpContext.Session.SetInt32("CurrecntSession", id);
            
            //ViewBag.Associ = _context.Course.Where(x => x.CourseAssociatedId == id).DefaultIfEmpty().ToList();
            //ViewBag.Pre = _context.PreRequest.Where(x => x.CourseId == id).DefaultIfEmpty().ToList();
            /*
             * The Above Added New
             */
            ViewBag.Metting = _context.Metting.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Matierial = _context.Material.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Task = _context.Task.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Chat = _context.ChatGroup.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            //ViewBag.Exams= _context.Exam.Where(x => x.Course == id).DefaultIfEmpty().ToList();
            var students = _context.Student.DefaultIfEmpty().ToList();
            var session = _context.Session.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Goals = _context.Goals.Where(x => x.CourseId == session.ElementAt(0).CourseId).DefaultIfEmpty().ToList();
            ViewBag.Topic = _context.Topic.Where(x => x.CourseId == session.ElementAt(0).CourseId).DefaultIfEmpty().ToList();
            var Mysession = _context.StudentsSession.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Exam = _context.Exam.ToList();


            var chatsGroub = _context.ChatGroup.Where(x => x.SessionId == id).ToList();
            var massages = _context.Message.ToList();

            var chats = _context.Chats.ToList();


            var cahtsContent = from cg in chatsGroub
                               join c in chats
                               on cg.ChatGroupId equals c.ChatGroupId
                               join m in massages on c.MessageId equals m.MessageId



                               select new ChatsContent
                               {

                                   ChatGroup = cg,
                                   Chats = c,
                                   Message = m,
                               };
            ViewBag.chats = cahtsContent;





            var thisSessionStudent = from std in students
                                     join ms in Mysession
                on std.StudentId equals ms.StudentId
                                     join s in session on ms.SessionId equals s.SessionId
                                     select new SessionAvailableStudents
                                     {
                                         Session = s,
                                         StudentsSession = ms,
                                         Student = std
                                     };
            ViewBag.myStudent = thisSessionStudent;


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

            return View(innerJoinForRegisteredCourses.ElementAt(0));
        }

     
        public IActionResult Calender()
        {
            ViewBag.Exam = _context.Exam.DefaultIfEmpty().ToList();
            ViewBag.ToDo = _context.ToDoList.Where(x=>x.StudentId== HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            ViewBag.Task = _context.Task.DefaultIfEmpty().ToList();
            return View();
        }
        public IActionResult ToDoList()
        {
            return View(_context.ToDoList.Where(x => x.StudentId== HttpContext.Session.GetInt32("Id")).ToList());
        }

        //byModal
        [HttpPost]
        public IActionResult AddToDo(string title, string desc)
        {
            ToDoList doList = new ToDoList();

            doList.TaskTitle = title;
            doList.Description = desc;
            //doList.IsDone = isdone;
            //doList.StartAt = start;
            //doList.DoneAt = end;
            //doList.Priority = priority;
            doList.StatusId = 1;
            doList.TeacherId = null;
            doList.StudentId = HttpContext.Session.GetInt32("Id");
            _context.Add(doList);
            _context.SaveChanges();

            return RedirectToAction("ToDoList");
        }
        public IActionResult DeleteToDo(int id)
        {
            var item = _context.ToDoList.Where(x => x.ToDoListId == id).First();
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("ToDoList");
            }
            else
            {
                return NotFound();
            }

        }
        //byModal
        //[HttpPost]
        public IActionResult UpdateToDo(int id, int statusid)
        {
            var doList = _context.ToDoList.Where(x => x.ToDoListId == id).First();
            if (doList != null)
            {
                doList.StatusId = statusid;
                doList.TeacherId = null;
                doList.StudentId = HttpContext.Session.GetInt32("Id");
                _context.Update(doList);
                _context.SaveChanges();

                return RedirectToAction("ToDoList");
            }
            else
            {
                return NotFound();
            }



        }
        [HttpPost]
        public IActionResult SendMassages(bool isTeacher, string text, int sessionId)
        {
            Message message = new Message();
            message.Text = text;
            message.IsSendByTeacher = isTeacher;
            message.SenderName = _context.Teacher.Where(x => x.TeacherId == HttpContext.Session.GetInt32("Id")).First().FullName;
            message.MassageDate = DateTime.Now;

            _context.Add(message);
            _context.SaveChanges();

            Chats chats = new Chats();
            chats.MessageId = _context.Message.OrderByDescending(x => x.MessageId).First().MessageId;
            chats.ChatGroupId = _context.ChatGroup.OrderByDescending(x => x.ChatGroupId).Where(x => x.SessionId == sessionId).First().ChatGroupId;
            _context.Add(chats);
            _context.SaveChanges();
            return RedirectToAction("SessionInfo", HttpContext.Session.GetInt32("CurrecntSession"));
            //return View();
        }
        public IActionResult UploadTask(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadTask(string Note, IFormFile taskFile)
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
                Models.StudentTask studentTask=new Models.StudentTask();
                studentTask.Notes = Note;

                _context.Add(studentTask);
                _context.SaveChanges();
            }
            return RedirectToAction("SessionInfo", HttpContext.Session.GetInt32("CurrecntSession"));
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Main");
        }
    }
}
