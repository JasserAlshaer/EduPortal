using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Option
    {
        public int OptionId { get; set; }
        public string Answer { get; set; }
        public bool? IsCorrect { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
