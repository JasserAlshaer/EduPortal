using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EduPortal.Models
{
    public partial class Course
    {
        public Course()
        {
            Exam = new HashSet<Exam>();
            Goals = new HashSet<Goals>();
            InverseCourseAssociated = new HashSet<Course>();
            PreRequestCourse = new HashSet<PreRequest>();
            PreRequestPrevouisCourse = new HashSet<PreRequest>();
            Session = new HashSet<Session>();
            Topic = new HashSet<Topic>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Description { get; set; }
        public string ArabicDescription { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedHour { get; set; }
        public int? PassMark { get; set; }
        public int? SpectializationId { get; set; }
        public int? CourseAssociatedId { get; set; }
        public string Image { get; set; }

        public virtual Course CourseAssociated { get; set; }
        public virtual Spectialization Spectialization { get; set; }
        public virtual ICollection<Exam> Exam { get; set; }
        public virtual ICollection<Goals> Goals { get; set; }
        public virtual ICollection<Course> InverseCourseAssociated { get; set; }
        public virtual ICollection<PreRequest> PreRequestCourse { get; set; }
        public virtual ICollection<PreRequest> PreRequestPrevouisCourse { get; set; }
        public virtual ICollection<Session> Session { get; set; }
        public virtual ICollection<Topic> Topic { get; set; }
    }
}
