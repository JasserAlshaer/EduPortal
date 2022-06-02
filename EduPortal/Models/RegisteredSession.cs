namespace EduPortal.Models
{
    public class RegisteredSession
    {
        
        public Session Session { get; set; }
        public Course Course { get; set; }
        public Spectialization Spectialization { get; set; }

       

        public Schedule Schedule { get; set; }  

        public Teacher Teacher { get; set; }
    }
}
