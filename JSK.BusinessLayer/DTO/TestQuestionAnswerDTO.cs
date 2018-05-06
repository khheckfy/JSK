using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSK.BusinessLayer.DTO
{
    public class TestQuestionAnswerDTO
    {
        public int TestQuestionAnswerId { set; get; }
        [Required(ErrorMessage = "Answer is empty")]
        [StringLength(1024, MinimumLength = 1, ErrorMessage = "Min length is 1, max 1024")]
        public string Answer { set; get; }
        public bool IsCorrect { set; get; }
        public bool IsActive { set; get; }
        public int TestQuestionId { set; get; }
    }
}
