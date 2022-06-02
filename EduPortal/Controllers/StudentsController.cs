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
        //public static List<Options> currentExam = new List<Options>();
        public static List<String> userAnswer = new List<string>();
        public static int examIndexPointer = 0;

        public IActionResult Index()
        {
            ViewBag.ToDo = _context.ToDoList.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();
            ViewBag.Tasks = _context.StudentTask.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();
            ViewBag.Exams = _context.StudentTakeExam.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();
            ViewBag.Attend = _context.StudentAttendanceRecord.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();
            ViewBag.Matierial = _context.StudentsFinishMaterial.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).Count();


            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();
            var status = _context.Status.DefaultIfEmpty().ToList();
            var user = _context.Student.Where(x => x.StudentId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            var profile = from s in spectilization
                          join u in user on s.SpectializationId equals u.SpectializationId
                          join st in status on u.StatusId equals st.StatusId

                          select new ProfileStudents
                          {
                              Spectialization = s,
                              Status = st,
                              Student = u
                          };
            return View(profile);
        }
        public IActionResult Courses()
        {
            var course = _context.Course.DefaultIfEmpty().ToList();
            var students = _context.Student.Where(x=>x.StudentId == HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            var session = _context.Session.DefaultIfEmpty().ToList();
            var Mysession = _context.StudentsSession.DefaultIfEmpty().ToList();
            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();
            var innerJoinForRegisteredCourses = from s in spectilization
                                         join c in course on s.SpectializationId equals c.SpectializationId
                                         join ses in session on c.CourseId equals ses.CourseId
                                         join myses in Mysession on ses.SessionId equals myses.SessionId
                                         join std in students on myses.StudentId equals std.StudentId
                                         select new RegisteredCourse
                                         {
                                            Spectialization=s,
                                            Course=c,
                                            Session=ses,
                                            StudentsSession=myses,
                                            Student=std
                                         };
            return View(innerJoinForRegisteredCourses);
            
        }
        public IActionResult CourseInfo(int id )
        {
            ViewBag.Goals = _context.Goals.Where(x=> x.CourseId==id).DefaultIfEmpty().ToList();
            ViewBag.Topic = _context.Topic.Where(x => x.CourseId == id).DefaultIfEmpty().ToList();
            ViewBag.Associ = _context.Course.Where(x=>x.CourseAssociatedId==id).DefaultIfEmpty().ToList();
            ViewBag.Pre = _context.PreRequest.Where(x => x.CourseId == id).DefaultIfEmpty().ToList();

            return View(_context.Course.Where(x=>x.CourseId==id).Single());
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
            ViewBag.Metting = _context.Metting.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Matierial = _context.Material.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Task = _context.Task.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Chat = _context.ChatGroup.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Attendance = _context.StudentAttendanceRecord.Where(x => x.SessionId == id && x.StudentId== HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            
            
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
                                                  
                                                    Schedule = myt,
                                                    Teacher = t
                                                };
            return View(innerJoinForRegisteredCourses);
        }

        public IActionResult Profile()
        {
            var spectilization = _context.Spectialization.DefaultIfEmpty().ToList();
            var status = _context.Status.DefaultIfEmpty().ToList();
            var user = _context.Student.Where(x=>x.StudentId== HttpContext.Session.GetInt32("Id")).DefaultIfEmpty().ToList();
            var profile = from s in spectilization
                                                join u in user on s.SpectializationId equals u.SpectializationId
                                                join st in status on u.StatusId equals st.StatusId
                                              
                                                select new ProfileStudents
                                                {
                                                    Spectialization = s,
                                                  Status = st,
                                                  Student=u
                                                };
            return View(profile);
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
       
        public IActionResult SubmitTask()
        {
            return View();
        }

        public IActionResult FinishMat()
        {
            return View();
        }

        public IActionResult AddToDo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToDo(string title, string desc, bool isdone, DateTime start, DateTime end
            , int priority)
        {
            ToDoList doList = new ToDoList();

            doList.TaskTitle = title;
            doList.Description = desc;
            //doList.IsDone = isdone;
            //doList.StartAt = start;
            //doList.DoneAt = end;
            //doList.Priority = priority;
            doList.TeacherId = null; 
            doList.StudentId = HttpContext.Session.GetInt32("Id");
            _context.Add(doList);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult DeleteToDo(int id)
        {
            var item = _context.ToDoList.Where(x => x.ToDoListId == id).First();
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
        public IActionResult UpdateToDo(int id)
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
        public IActionResult UpdateToDo(int id, string title, string desc, bool isdone, DateTime start, DateTime end
            , int priority) 
        {
            var doList = _context.ToDoList.Where(x => x.ToDoListId == id).First();
            if (doList != null)
            {
                doList.TaskTitle = title;
                doList.Description = desc;
                //doList.IsDone = isdone;
                //doList.StartAt = start;
                //doList.DoneAt = end;
                //doList.Priority = priority;
                doList.TeacherId = null;
                doList.StudentId = HttpContext.Session.GetInt32("Id");
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

        
        public IActionResult Marks()
        {
            return View();
        }
        public IActionResult UploadTask()
        {
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
            return View();
        }
        public async Task<IActionResult> Exam(int id)
        {
            //List<Options> options = _context.Options.Where(recprd => recprd.ExamId == id).ToList();

            //currentExam = options;


            //CustomerExam customerExam = new CustomerExam();
            //customerExam.ExamId = id;
            //customerExam.CustomerId = HttpContext.Session.GetInt32("Id");

            //HttpContext.Session.SetInt32("ExamId", id);

            //_context.CustomerExam.Add(customerExam);
            //await _context.SaveChangesAsync();

            return RedirectToAction("ExamContent");

        }

        public void ExamContent()
        {
            //ViewBag.Index = examIndexPointer;
            //ViewBag.Text = "Next";
            //return View("Exam", currentExam.ElementAt(0));
        }

        [HttpPost]
        public void IncreaseExamIndex(int id, string Answer)
        {
        //    userAnswer.Insert(examIndexPointer, Answer);
        //    if (userAnswer.Count() == currentExam.Count())
        //    {
        //        return Redirect("SubmitExamAndSendJobApplication");
        //    }
        //    if ((examIndexPointer + 3) > currentExam.Count())
        //    {
        //        ++examIndexPointer;

        //        ViewBag.Index = examIndexPointer;
        //        ViewBag.IsFinish = true;
        //        ViewBag.Text = "Submit And Finish";
        //        userAnswer.Count();
        //        return View("Exam", currentExam.ElementAt(examIndexPointer));

        //    }
        //    else
        //    {
        //        ++examIndexPointer;

        //        ViewBag.Index = examIndexPointer;
        //        ViewBag.IsFinish = false;
        //        ViewBag.Text = "Next";
        //        userAnswer.Count();
        //        return View("Exam", currentExam.ElementAt(examIndexPointer));

        //    }

        }


        public void SubmitExamAndSendJobApplication()
        {
            //int result = 0;
            //for (int i = 0; i < userAnswer.Count; i++)
            //{
            //    if (userAnswer.ElementAt(i) == currentExam.ElementAt(i).CorrectAnswer)
            //    {
            //        result++;
            //    }
            //}

            //var examInfo = _context.Exam.Where(recored => recored.ExamId == HttpContext.Session.GetInt32("ExamId")).SingleOrDefault();
            //if (examInfo == null)
            //{
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    int weightOfMark = 0;
            //    weightOfMark = (int)examInfo.PassMark / examInfo.QuestionSum;
            //    result *= weightOfMark;
            //    if (result >= examInfo.PassMark)
            //    {

            //        CustomerJobs jobs = new CustomerJobs();
            //        jobs.CustomerId = (long)HttpContext.Session.GetInt32("Id");
            //        jobs.EmploymentId = _context.EmploymentAd.Where(e => e.ExamId == HttpContext.Session.GetInt32("ExamId"))
            //        .FirstOrDefault().EmploymentAdId;
            //        jobs.JobApplicationStatusId = 1;
            //        jobs.LastUpdate = DateTime.Now;

            //        _context.CustomerJobs.Add(jobs);
            //        _context.SaveChanges();

            //        return RedirectToAction("MyJobApplications");
            //    }
            //    else
            //    {
            //        return RedirectToAction("Error");
            //    }

            //}

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
