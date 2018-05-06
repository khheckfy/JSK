using JSK.BusinessLayer.DTO;
using System.ComponentModel.DataAnnotations;

namespace JSK.Web.Models
{
    public class ManageTestModel
    {
        public ManageTestModel()
        {
        }

        public int TestId { set; get; }
        [Required(ErrorMessage = "Name is empty")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Min length is 3, max 255")]
        public string TestName { set; get; }
        public bool IsRandomQuestions { set; get; }
        public string Questions { set; get; }
    }
}
