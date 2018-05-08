using System;
using System.Collections.Generic;

namespace JSK.BusinessLayer.DTO
{
    /// <summary>
    /// User test entity
    /// </summary>
    public class UserTestDTO
    {
        /// <summary>
        /// id
        /// </summary>
        public Guid UserTestId { set; get; }
        /// <summary>
        /// user id
        /// </summary>
        public int UserId { set; get; }
        /// <summary>
        /// test id
        /// </summary>
        public int TestId { set; get; }
        /// <summary>
        ///  date of create
        /// </summary>
        public DateTime CreatedOn { set; get; }

        /// <summary>
        /// test entity
        /// </summary>
        public TestDTO Test { set; get; }
        /// <summary>
        /// answers
        /// </summary>
        public List<UserTestAnswerDTO> UserTestAnswers { set; get; }

    }
}
