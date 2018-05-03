using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JSK.Domain.Entities
{
    [Table("TestQuestionAnswers")]
    public class TestQuestionAnswer
    {
        [Key]
        public int TestQuestionAnswerId { set; get; }
        public int TestQuestionId { set; get; }
        [StringLength(1024)]
        public string Answer { set; get; }
        public bool IsCorrect { set; get; }
    }
}
