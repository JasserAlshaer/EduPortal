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
            return View(profile.ElementAt(0));
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

      

        public IActionResult SessionInformationShow([FromQuery]int id)
        {
            HttpContext.Session.SetInt32("CurrecntSession", id);
            //int id = 1;
            ViewBag.Metting = _context.Metting.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Matierial = _context.Material.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Task = _context.Task.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Chat = _context.ChatGroup.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            //ViewBag.Exams= _context.Exam.Where(x => x.Course == id).DefaultIfEmpty().ToList();
            var students = _context.Student.DefaultIfEmpty().ToList();
            var session = _context.Session.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            var Mysession = _context.StudentsSession.Where(x => x.SessionId == id).DefaultIfEmpty().ToList();
            ViewBag.Exam= _context.Exam.ToList();


            var chatsGroub = _context.ChatGroup.Where(x => x.SessionId == id).ToList();
            var massages = _context.Message.ToList();
            
            var chats=_context.Chats.ToList();
            

            var cahtsContent = from cg in chatsGroub
                               join c in chats
                               on cg.ChatGroupId equals c.ChatGroupId
                               join m in massages on c.MessageId equals m.MessageId
                              

                               
                               select new ChatsContent
                               {
                                 
                                   ChatGroup=cg,
                                   Chats=c,
                                   Message=m,
                               };
            ViewBag.chats = cahtsContent;





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
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
            }
        }
        //byModal
        [HttpPost]
        public IActionResult InsertExam(string title, int cid, int sum, int mark,DateTime start ,DateTime end)

        {
            Exam exam=new Exam();
            exam.Title = title; 
            exam.CourseId = cid;
            exam.SumOfQuestion = sum;
            exam.Mark = mark;
            exam.StartDateandTime = start;
            exam.EndDateandTime = end; 
            exam.IsActive= true;

            _context.Add(exam);
            _context.SaveChanges();
            return RedirectToAction("SessionInformationShow", HttpContext.Session.GetInt32("CurrecntSession"));
        }



        //byModal
        [HttpPost]
        public async Task<IActionResult> InsertMatierial(string title,string desc, IFormFile path,int sid)
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
                m.SessionId = sid;




                _context.Add(m);
                _context.SaveChanges();
            }

            return RedirectToAction("SessionInformationShow", HttpContext.Session.GetInt32("CurrecntSession"));
        }

       

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


            return RedirectToAction("GetTaskAnswer", stdTask.TaskId);


        }


        public IActionResult QuestionBank(int id)
        {
            ViewBag.Id = id;


            var questions = _context.Question.ToList();
            //var examQuestion = _context.ExamQuestion.Where(x => x.ExamId == id);
            var qType=_context.QuestionType.ToList();

            var jo = from q in questions
                     join qt in qType on q.QuestionTypeId equals qt.QuestionTypeId
                     select new QuestionGrid
                     {
                       
                         Question=q
                         ,QuestionType=qt
                     };
            return View(jo);
        }
        public IActionResult GetExamsMark(int id)
        {

            return View();
            //var questions = _context.Question.ToList();
            ////var examQuestion = _context.ExamQuestion.Where(x => x.ExamId == id);
            //var qType = _context.QuestionType.ToList();
            //var stdexam=_context.StudentTakeExam.Where(x => x.ExamId == id);
            //var std = _context.Student.ToList();
            //var jo = from q in questions
                   
            //         join qt in qType on q.QuestionTypeId equals qt.QuestionTypeId
                     
            //         join s in std on se.StudentId equals s.StudentId
            //         select new ExamMarksGrid
            //         {
                        
            //             Question = q
            //             ,
            //             QuestionType = qt,

            //             StudentTakeExam=se,
            //             Student=s
            //         };
            //return View(jo);
        }

        

        public IActionResult InsertQuestion(int id)
        {
            ViewBag.Id = id;
            return View();
        }
     
        [HttpPost]
        public async Task<IActionResult> InsertQuestionMuiltable(int examid, string title,string option1, string option2
            , string option3, string option4,IFormFile file)

        {
            Question question = new Question();
            if (file != null)
            {
                String wRootPath = _env.WebRootPath;
                String fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                var path1 = Path.Combine(wRootPath + "/Uploads", fileName);

                using (var filestream = new FileStream(path1, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
                question.Image = fileName;
            }
            else
            {
                question.Image = null;
            }
            question.Text = title;
            question.QuestionTypeId = 1;
            question.TeacherId = HttpContext.Session.GetInt32("Id");
            question.IsActive = true;
            _context.Add(question);
            _context.SaveChanges();

            //bind with exam

            ExamQuestion examQuestion = new ExamQuestion(); 
            examQuestion.ExamId= examid;
            examQuestion.QuestionId= _context.Question.OrderByDescending(x => x.QuestionId).First().QuestionId;
            _context.Add(examQuestion);
            _context.SaveChanges();
            //Store Options

            Option option = new Option();
            option.QuestionId = _context.Question.OrderByDescending(x => x.QuestionId).First().QuestionId;
            option.Answer = option1;
            option.IsCorrect= true;
            _context.Add(option);
            _context.SaveChanges();


            Option o2 = new Option();
            o2.QuestionId = _context.Question.OrderByDescending(x => x.QuestionId).First().QuestionId;
            o2.Answer = option2;
            o2.IsCorrect = false;
            _context.Add(o2);
            _context.SaveChanges();


            Option o3 = new Option();
            o3.QuestionId = _context.Question.OrderByDescending(x => x.QuestionId).First().QuestionId;
            o3.Answer = option3;
            o3.IsCorrect = false;
            _context.Add(o2);
            _context.SaveChanges();

            Option o4 = new Option();
            o4.QuestionId = _context.Question.OrderByDescending(x => x.QuestionId).First().QuestionId;
            o4.Answer = option4;
            o4.IsCorrect = false;
            _context.Add(o2);
            _context.SaveChanges();


            return RedirectToAction("QuestionBank", examid);
        }

        //byModal
        [HttpPost]
        public async Task<IActionResult> InsertTask(string title,string note,int mark,int weight,IFormFile taskFile
            ,int sid, bool lastSubmit,DateTime start, DateTime end, DateTime lastdate)
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
                task.SessionId = sid;
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

            return RedirectToAction("SessionInformationShow", HttpContext.Session.GetInt32("CurrecntSession"));
        }
        //byModal
        [HttpPost]
        public IActionResult AddToDo(string title,string desc,DateTime end)
        {
            ToDoList doList= new ToDoList();

            doList.TaskTitle = title;
            doList.Description = desc;
            //doList.IsDone = isdone;
            //doList.StartAt = start;
            //doList.DoneAt = end;
            //doList.Priority = priority;
            doList.StatusId = 1;
            doList.StudentId = null;
            doList.TeacherId = HttpContext.Session.GetInt32("Id");
            doList.StartDate= DateTime.Now;
            doList.EndDate= end;
             _context.Add(doList);
            _context.SaveChanges();

            return RedirectToAction("ToDoList");
        }
        public IActionResult DeleteToDo(int id)
        {
            var item=_context.ToDoList.Where(x=>x.ToDoListId==id).FirstOrDefault();
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

        
       public IActionResult DeleteMatierial(int id)
        {
            var item = _context.Material.Where(x => x.MaterialId == id).First();
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChanges();
                return RedirectToAction("SessionInformationShow", HttpContext.Session.GetInt32("CurrecntSession"));
            }
            else
            {
                return NotFound();
            }

        }
        //byModal
        //[HttpPost]
        public IActionResult UpdateToDo(int id,int statusid)
        {
            var doList = _context.ToDoList.Where(x => x.ToDoListId == id).First();
            if (doList != null)
            {
                doList.StatusId = statusid;
                doList.StudentId = null;
                doList.TeacherId = HttpContext.Session.GetInt32("Id");
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
        public IActionResult SendMassages(bool isTeacher,string text,int sessionId)
        {
            Message message = new Message();
            message.Text = text;
            message.IsSendByTeacher= isTeacher;
            message.SenderName = _context.Teacher.Where(x => x.TeacherId == HttpContext.Session.GetInt32("Id")).First().FullName;
            message.MassageDate= DateTime.Now;

            _context.Add(message);  
            _context.SaveChanges();

            Chats chats = new Chats();  
            chats.MessageId=_context.Message.OrderByDescending(x=>x.MessageId).First().MessageId;
            chats.ChatGroupId=_context.ChatGroup.OrderByDescending(x=>x.ChatGroupId).Where(x=>x.SessionId==sessionId).First().ChatGroupId;
            _context.Add(chats);
            _context.SaveChanges();
            return RedirectToAction("SessionInformationShow", HttpContext.Session.GetInt32("CurrecntSession"));
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

            return RedirectToAction("Index", "Main");
        }
    }
}
