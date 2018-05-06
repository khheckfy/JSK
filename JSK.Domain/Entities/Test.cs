using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSK.Domain.Entities
{
    [Table("Tests")]
    public class Test
    {
        [Key]
        public int TestId { set; get; }
        [StringLength(255)]
        public string Name { set; get; }
        public bool IsRandomQuestionsOrder { set; get; }
        public bool IsActive { set; get; }

        public ICollection<TestQuestion> TestQuestions { get; set; }
        public virtual ICollection<UserTest> UserTests { set; get; }
    }
}
