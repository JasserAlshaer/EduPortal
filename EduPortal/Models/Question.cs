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
            Option = new HashSet<Option>();
        }

        public int QuestionId { get; set; }
        public string Text { get; set; }
        public bool? IsActive { get; set; }
        public int? QuestionTypeId { get; set; }
        public int? TeacherId { get; set; }
        public string Image { get; set; }
        public int? ExamId { get; set; }

        public virtual Exam Exam { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Option> Option { get; set; }
    }
}
