using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSK.Domain.Entities
{
    [Table("UserTests")]
    public class UserTest
    {
        [Key]
        public Guid UserTestId { set; get; }
        public int UserId { set; get; }
        public int TestId { set; get; }
        public DateTime CreatedOn { set; get; }

        public User User { set; get; }
        public Test Test { set; get; }

        public virtual ICollection<UserTestAnswer> UserTestAnswers { set; get; }
    }
}
