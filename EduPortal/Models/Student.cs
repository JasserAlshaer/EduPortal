using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Student
    {
        public Student()
        {
            Login = new HashSet<Login>();
            StudentAttendanceRecord = new HashSet<StudentAttendanceRecord>();
            StudentTakeExam = new HashSet<StudentTakeExam>();
            StudentTask = new HashSet<StudentTask>();
            StudentsSession = new HashSet<StudentsSession>();
            ToDoList = new HashSet<ToDoList>();
        }

        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public double? Gpa { get; set; }
        public int? SpectializationId { get; set; }
        public int? StatusId { get; set; }
        public string Image { get; set; }

        public virtual Spectialization Spectialization { get; set; }
        public virtual Status Status { get; set; }
        public virtual StudentsFinishMaterial StudentsFinishMaterial { get; set; }
        public virtual ICollection<Login> Login { get; set; }
        public virtual ICollection<StudentAttendanceRecord> StudentAttendanceRecord { get; set; }
        public virtual ICollection<StudentTakeExam> StudentTakeExam { get; set; }
        public virtual ICollection<StudentTask> StudentTask { get; set; }
        public virtual ICollection<StudentsSession> StudentsSession { get; set; }
        public virtual ICollection<ToDoList> ToDoList { get; set; }
    }
}
