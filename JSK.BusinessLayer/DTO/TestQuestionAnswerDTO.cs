using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSK.BusinessLayer.DTO
{
    /// <summary>
    /// Answer for question
    /// </summary>
    public class TestQuestionAnswerDTO
    {
        /// <summary>
        /// Answer test id
        /// </summary>
        public int TestQuestionAnswerId { set; get; }
        /// <summary>
        /// Answer text
        /// </summary>
        [Required(ErrorMessage = "Answer is empty")]
        [StringLength(1024, MinimumLength = 1, ErrorMessage = "Min length is 1, max 1024")]
        public string Answer { set; get; }
        /// <summary>
        /// Answer is correct
        /// </summary>
        public bool IsCorrect { set; get; }
        /// <summary>
        /// Is active answer
        /// </summary>
        public bool IsActive { set; get; }
        /// <summary>
        /// Question id of answer
        /// </summary>
        public int TestQuestionId { set; get; }
    }
}
