using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Session = new HashSet<Session>();
        }

        public int TeacherId { get; set; }
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string Pio { get; set; }
        public string IsActive { get; set; }
        public int? SpectializationId { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Spectialization Spectialization { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
