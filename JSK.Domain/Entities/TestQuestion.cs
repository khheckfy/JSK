using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSK.Domain.Entities
{
    [Table("TestQuestion")]
    public class TestQuestion
    {
        [Key]
        public int TestQuestionId { set; get; }
        public int TestId { set; get; }
        public string Question { set; get; }
        public bool IsSingleAnswer { set; get; }
    }
}
