using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSK.BusinessLayer.DTO
{
    /// <summary>
    /// Question of test entity
    /// </summary>
    public class TestQuestionDTO
    {
        /// <summary>
        /// id of question
        /// </summary>
        public int TestQuestionId { set; get; }
        /// <summary>
        /// Text of question
        /// </summary>
        [Required(ErrorMessage = "Question is empty")]
        [StringLength(1024, MinimumLength = 1, ErrorMessage = "Min length is 1, max 1024")]
        public string Question { set; get; }
        /// <summary>
        /// Is single answer for this question
        /// </summary>
        public bool IsSingleAnswer { set; get; }
        /// <summary>
        /// Id test of this question
        /// </summary>
        public int TestId { set; get; }
        /// <summary>
        /// Question is active
        /// </summary>
        public bool IsActive { set; get; }
        /// <summary>
        /// Answers
        /// </summary>
        public List<TestQuestionAnswerDTO> TestQuestionAnswers { set; get; }
    }
}
