using JSK.BusinessLayer.DTO;
using System;
using System.Collections.Generic;

namespace JSK.BusinessLayer.Models
{
    public class TestItemModel
    {
        public TestItemModel()
        {
            Answers = new List<TestQuestionAnswerDTO>();
        }

        public Guid ID { set; get; }
        public string TestName { set; get; }
        public int TestId { set; get; }

        public string QuestionName { set; get; }
        public int QuestionId { set; get; }
        public bool IsSingleAnswer { set; get; }

        public List<TestQuestionAnswerDTO> Answers { set; get; }

        public bool IsComplete { set; get; } = false;
        //public int FullCount { set; get; } = 0;
        //public int CorrectCount { set; get; } = 0;
        //public int FailCount { get { return FullCount - CorrectCount; } }
    }
}
