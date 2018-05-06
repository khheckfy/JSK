using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSK.Domain.Entities
{
    [Table("TestQuestionAnswers")]
    public class TestQuestionAnswer
    {
        [Key]
        public int TestQuestionAnswerId { set; get; }
        
        [StringLength(1024)]
        public string Answer { set; get; }
        public bool IsCorrect { set; get; }
        public bool IsActive { set; get; }

        public int TestQuestionId { set; get; }
        public TestQuestion TestQuestion { set; get; }

        public virtual ICollection<UserTestAnswer> UserTestAnswers { set; get; }
    }
}
