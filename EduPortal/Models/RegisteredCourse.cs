namespace EduPortal.Models
{
    public class RegisteredCourse
    {
        public Student Student { get; set; }    
        public Session Session { get; set; }    
        public Course Course { get; set; }
        public Spectialization Spectialization { get; set; } 
        
        public StudentsSession StudentsSession { get; set; }    
    }
}
