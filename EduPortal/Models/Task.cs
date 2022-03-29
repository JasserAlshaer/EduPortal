using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Task
    {
        public Task()
        {
            StudentTask = new HashSet<StudentTask>();
        }

        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public int? Mark { get; set; }
        public int? Weight { get; set; }
        public string FilePath { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public bool? IsAllowLateSubmmition { get; set; }
        public DateTime? LastAllowedSubmmation { get; set; }
        public int? SessionId { get; set; }

        public virtual Session Session { get; set; }
        public virtual ICollection<StudentTask> StudentTask { get; set; }
    }
}
