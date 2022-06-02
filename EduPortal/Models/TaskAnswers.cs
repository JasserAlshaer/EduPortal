namespace EduPortal.Models
{
    public class TaskAnswers
    {
        public Task Task { get; set; }
        public Student Student { get; set; }    
        public StudentTask StudentTask { get; set; }
    }
}
