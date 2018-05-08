using System.Collections.Generic;

namespace JSK.BusinessLayer.DTO
{
    /// <summary>
    /// TEst entity
    /// </summary>
    public class TestDTO
    {
        /// <summary>
        /// Id of test
        /// </summary>
        public int TestId { set; get; }
        /// <summary>
        /// Name test
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// Question for test is random
        /// </summary>
        public bool IsRandomQuestionsOrder { set; get; }

        /// <summary>
        /// Test is active
        /// </summary>
        public bool IsActive { set; get; }

        /// <summary>
        /// Questions for test
        /// </summary>
        public List<TestQuestionDTO> TestQuestions { set; get; }
    }
}
