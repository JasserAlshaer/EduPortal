using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class StudentTask
    {
        public int StudentTaskId { get; set; }
        public double? ActualMark { get; set; }
        public double? FinalResult { get; set; }
        public string Notes { get; set; }
        public string TeacherResponse { get; set; }
        public int? StudentId { get; set; }
        public int? TaskId { get; set; }
        public string AttactmentFile { get; set; }
        public DateTime? SubmittedAt { get; set; }

        public virtual Student Student { get; set; }
        public virtual Task Task { get; set; }
    }
}
