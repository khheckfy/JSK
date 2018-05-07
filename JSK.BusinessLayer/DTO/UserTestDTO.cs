using System;
using System.Collections.Generic;
using System.Text;

namespace JSK.BusinessLayer.DTO
{
    public class UserTestDTO
    {
        public Guid UserTestId { set; get; }
        public int UserId { set; get; }
        public int TestId { set; get; }
        public DateTime CreatedOn { set; get; }

        public TestDTO Test { set; get; }
        public List<UserTestAnswerDTO> UserTestAnswers { set; get; }

    }
}
