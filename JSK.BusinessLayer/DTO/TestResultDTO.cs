using System;

namespace JSK.BusinessLayer.DTO
{
    /// <summary>
    /// Result test for view in manage
    /// </summary>
    public class TestResultDTO
    {
        /// <summary>
        /// Id user test
        /// </summary>
        public Guid UserTestId { set; get; }
        /// <summary>
        /// User name
        /// </summary>
        public string UserName { set; get; }
        /// <summary>
        /// TEst name
        /// </summary>
        public string TestName { set; get; }
        /// <summary>
        /// User email
        /// </summary>
        public string UserEmail { set; get; }
        /// <summary>
        /// Date of create test user
        /// </summary>
        public DateTime CreatedOn { set; get; }
    }
}
