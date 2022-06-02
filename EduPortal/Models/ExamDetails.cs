namespace EduPortal.Models
{
    public class ExamDetails
    {
        public Exam Exam { get; set; }  
        public ExamQuestion ExamQuestion { get; set; }
        public Question Question { get; set; }  
        public Option Option { get; set; }

        public QuestionType QuestionType { get; set; }
    }
}
