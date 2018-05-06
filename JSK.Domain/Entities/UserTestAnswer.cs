using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSK.Domain.Entities
{
    [Table("UserTestAnswers")]
    public class UserTestAnswer
    {
        [Key]
        public int UserTestAnswerId { set; get; }

        [StringLength(1024)]
        public string AnswerText { set; get; }

        public int UserId { set; get; }
        public User User { set; get; }

        public int? TestQuestionAnswerId { set; get; }
        public TestQuestionAnswer TestQuestionAnswer { set; get; }

        public int TestQuestionId { set; get; }
        public TestQuestion TestQuestion { set; get; }

        public Guid? UserTestId { set; get; }
        public UserTest UserTest { set; get; }
    }
}
