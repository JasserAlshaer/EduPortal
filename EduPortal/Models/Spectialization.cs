using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Spectialization
    {
        public Spectialization()
        {
            Course = new HashSet<Course>();
            Student = new HashSet<Student>();
            Teacher = new HashSet<Teacher>();
        }

        public int SpectializationId { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
        public int? CollageId { get; set; }

        public virtual Collage Collage { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Teacher> Teacher { get; set; }
    }
}
