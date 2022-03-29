using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class StudentTakeExam
    {
        public int StudentTakeExamId { get; set; }
        public DateTime? StartExamAt { get; set; }
        public DateTime? EndExamAt { get; set; }
        public double? ActualMark { get; set; }
        public double? FinalResult { get; set; }
        public string Notes { get; set; }
        public int? ExamId { get; set; }
        public int? StudentId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual Student Student { get; set; }
    }
}
