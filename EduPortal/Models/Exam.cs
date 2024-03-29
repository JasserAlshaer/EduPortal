﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Exam
    {
        public Exam()
        {
            Question = new HashSet<Question>();
            StudentTakeExam = new HashSet<StudentTakeExam>();
        }

        public int ExamId { get; set; }
        public DateTime? StartDateandTime { get; set; }
        public DateTime? EndDateandTime { get; set; }
        public int? Mark { get; set; }
        public int? PassMark { get; set; }
        public int? SumOfQuestion { get; set; }
        public int? Weight { get; set; }
        public int? CourseId { get; set; }
        public string Title { get; set; }
        public bool? IsActive { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<Question> Question { get; set; }
        public virtual ICollection<StudentTakeExam> StudentTakeExam { get; set; }
    }
}
