namespace EduPortal.Models
{
    public class ExamMarksGrid
    {
      public Exam Exam { get; set; }
        public Student Student { get; set; }    

        public StudentTakeExam StudentTakeExam { get; set; }    
    }
}
