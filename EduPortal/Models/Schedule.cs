using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Session = new HashSet<Session>();
        }

        public int ScheduleId { get; set; }
        public string Name { get; set; }
        public int? DayPerEachWeek { get; set; }

        public virtual ICollection<Session> Session { get; set; }
    }
}
