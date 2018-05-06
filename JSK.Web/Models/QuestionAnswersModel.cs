using JSK.BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSK.Web.Models
{
    public class QuestionAnswersModel
    {
        public string TestName { set; get; }
        public int TestId { set; get; }
        public List<TestQuestionDTO> Questions { set; get; }
    }
}
