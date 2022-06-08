using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class ToDoList
    {
        public int ToDoListId { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual StatusToDoList Status { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
