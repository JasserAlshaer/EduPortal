using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class RegistrationStatus
    {
        public RegistrationStatus()
        {
            Student = new HashSet<Student>();
        }

        public int RegistrationStatusId { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }

        public virtual ICollection<Student> Student { get; set; }
    }
}
