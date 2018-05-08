namespace JSK.BusinessLayer.DTO
{
    /// <summary>
    /// Answer entity
    /// </summary>
    public class UserTestAnswerDTO
    {
        /// <summary>
        /// ID
        /// </summary>
        public int UserTestAnswerId { set; get; }
        /// <summary>
        /// Text of answer
        /// </summary>
        public string AnswerText { set; get; }
        /// <summary>
        /// id usesr
        /// </summary>
        public int UserId { set; get; }
        /// <summary>
        /// selected answer from test
        /// </summary>
        public int TestQuestionAnswerId { set; get; }
        /// <summary>
        /// Answer entity
        /// </summary>
        public TestQuestionAnswerDTO TestQuestionAnswer { set; get; }
        /// <summary>
        /// id of question
        /// </summary>
        public int TestQuestionId { set; get; }
    }
}
