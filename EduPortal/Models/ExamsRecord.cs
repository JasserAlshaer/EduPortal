namespace EduPortal.Models
{
    public class ExamsRecord
    {
        public Course Course { get; set; }  
        public Session Session { get; set; }
        public Exam Exam { get; set; }
        public Student Student { get; set; }

        public StudentsSession StudentsSession { get; set; }
    }
}
