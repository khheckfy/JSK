using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JSK.BusinessLayer.DTO
{
    public class TestQuestionDTO
    {
        public int TestQuestionId { set; get; }
        [Required(ErrorMessage = "Question is empty")]
        [StringLength(1024, MinimumLength = 3, ErrorMessage = "Min length is 3, max 1024")]
        public string Question { set; get; }
        public bool IsSingleAnswer { set; get; }
        public int TestId { set; get; }
        public bool IsActive { set; get; }
        public List<TestQuestionAnswerDTO> TestQuestionAnswers { set; get; }
    }
}
