namespace JSK.BusinessLayer.DTO
{
    public class UserTestAnswerDTO
    {
        public int UserTestAnswerId { set; get; }
        public string AnswerText { set; get; }
        public int UserId { set; get; }
        public int TestQuestionAnswerId { set; get; }
        public TestQuestionAnswerDTO TestQuestionAnswer { set; get; }
        public int TestQuestionId { set; get; }
    }
}
