namespace EduPortal.Models
{
    public class ExamMarksGrid
    {
        public Question Question { get; set; }
        public QuestionType QuestionType { get; set; }
        public ExamQuestion ExamQuestion { get; set; }
        public Student Student { get; set; }    

        public StudentTakeExam StudentTakeExam { get; set; }    
    }
}
