namespace JSK.BusinessLayer.Models
{
    /// <summary>
    /// Answer of user from page for save to results
    /// </summary>
    public class UserAnswerModel
    {
        /// <summary>
        /// answers id for question
        /// </summary>
        public int[] Answers { set; get; }
        /// <summary>
        /// answer text if question not answers select
        /// </summary>
        public string AnswerText { set; get; }
        /// <summary>
        /// id of question
        /// </summary>
        public int QuestionId { set; get; }
        /// <summary>
        /// question not answers and is text answer
        /// </summary>
        public bool IsTextAnser { set; get; }
        /// <summary>
        /// is valid model
        /// </summary>
        public bool IsValid { set; get; }
        /// <summary>
        /// user test id record
        /// </summary>
        public System.Guid UserTetstId { set; get; }
    }
}
