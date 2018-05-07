namespace JSK.BusinessLayer.Models
{
    public class UserAnswerModel
    {
        public int[] Answers { set; get; }
        public string AnswerText { set; get; }
        public int QuestionId { set; get; }
        public bool IsTextAnser { set; get; }
        public bool IsValid { set; get; }
        public System.Guid UserTetstId { set; get; }
    }
}
