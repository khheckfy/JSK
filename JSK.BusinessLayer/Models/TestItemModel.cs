using JSK.BusinessLayer.DTO;
using System;
using System.Collections.Generic;

namespace JSK.BusinessLayer.Models
{
    /// <summary>
    /// Model of test for return, when user click the next question
    /// </summary>
    public class TestItemModel
    {
        public TestItemModel()
        {
            Answers = new List<TestQuestionAnswerDTO>();
        }

        /// <summary>
        /// User test id
        /// </summary>
        public Guid ID { set; get; }
        /// <summary>
        /// Test name
        /// </summary>
        public string TestName { set; get; }
        /// <summary>
        /// Test id
        /// </summary>
        public int TestId { set; get; }
        /// <summary>
        /// Question Name
        /// </summary>
        public string QuestionName { set; get; }
        /// <summary>
        /// New Question Id
        /// </summary>
        public int QuestionId { set; get; }
        /// <summary>
        /// check box or radio select list
        /// </summary>
        public bool IsSingleAnswer { set; get; }
        /// <summary>
        /// Answers for this questions
        /// </summary>
        public List<TestQuestionAnswerDTO> Answers { set; get; }
        /// <summary>
        /// Test is complete
        /// </summary>
        public bool IsComplete { set; get; } = false;
        //public int FullCount { set; get; } = 0;
        //public int CorrectCount { set; get; } = 0;
        //public int FailCount { get { return FullCount - CorrectCount; } }
    }
}
