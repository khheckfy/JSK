using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSK.Domain.Entities
{
    [Table("TestQuestions")]
    public class TestQuestion
    {
        [Key]
        public int TestQuestionId { set; get; }
        public int TestId { set; get; }
        [StringLength(1024)]
        public string Question { set; get; }
        public bool IsSingleAnswer { set; get; }
    }
}
