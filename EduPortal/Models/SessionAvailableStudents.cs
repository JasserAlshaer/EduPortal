namespace EduPortal.Models
{
    public class SessionAvailableStudents
    {
        public Student  Student { get; set; }
        public StudentsSession StudentsSession { get; set; }
        public Session Session { get; set; }
    }
}
