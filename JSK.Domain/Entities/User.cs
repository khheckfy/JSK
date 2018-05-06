using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSK.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { set; get; }
        [StringLength(255)]
        public string Email { set; get; }
        [StringLength(255)]
        public string Name { set; get; }

        public virtual ICollection<UserTestAnswer> UserTestAnswers { set; get; }
    }
}
