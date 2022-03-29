using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class StudentAttendanceRecord
    {
        public int StudentAttendanceRecordId { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsAbsence { get; set; }
        public string Note { get; set; }
        public int? SessionId { get; set; }
        public int? StudentId { get; set; }

        public virtual Session Session { get; set; }
        public virtual Student Student { get; set; }
    }
}
