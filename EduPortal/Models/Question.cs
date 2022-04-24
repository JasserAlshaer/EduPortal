﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Question
    {
        public Question()
        {
            ExamQuestion = new HashSet<ExamQuestion>();
            Option = new HashSet<Option>();
        }

        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsHaveMultipleCorrectAnswer { get; set; }
        public int? QuestionTypeId { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }

        public virtual Course Course { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<ExamQuestion> ExamQuestion { get; set; }
        public virtual ICollection<Option> Option { get; set; }
    }
}