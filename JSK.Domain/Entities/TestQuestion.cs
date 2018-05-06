using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSK.Domain.Entities
{
    [Table("TestQuestions")]
    public class TestQuestion
    {
        [Key]
        public int TestQuestionId { set; get; }
        
        [StringLength(1024)]
        public string Question { set; get; }
        public bool IsSingleAnswer { set; get; }
        public bool IsActive { set; get; }

        public int TestId { set; get; }
        public Test Test { set; get; }

        public virtual ICollection<TestQuestionAnswer> TestQuestionAnswers { set; get; }
        public virtual ICollection<UserTestAnswer> UserTestAnswers { set; get; }
    }
}
