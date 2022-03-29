using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Session
    {
        public Session()
        {
            ChatGroup = new HashSet<ChatGroup>();
            Material = new HashSet<Material>();
            Metting = new HashSet<Metting>();
            StudentAttendanceRecord = new HashSet<StudentAttendanceRecord>();
            StudentsSession = new HashSet<StudentsSession>();
            Task = new HashSet<Task>();
        }

        public int SessionId { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public TimeSpan? LectureStartTime { get; set; }
        public TimeSpan? LectureEndTime { get; set; }
        public bool? IsActive { get; set; }
        public int? ScheduleId { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }

        public virtual Course Course { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<ChatGroup> ChatGroup { get; set; }
        public virtual ICollection<Material> Material { get; set; }
        public virtual ICollection<Metting> Metting { get; set; }
        public virtual ICollection<StudentAttendanceRecord> StudentAttendanceRecord { get; set; }
        public virtual ICollection<StudentsSession> StudentsSession { get; set; }
        public virtual ICollection<Task> Task { get; set; }
    }
}
