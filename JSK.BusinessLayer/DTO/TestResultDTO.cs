using System;

namespace JSK.BusinessLayer.DTO
{
    public class TestResultDTO
    {
        public Guid UserTestId { set; get; }
        public string UserName { set; get; }
        public string TestName { set; get; }
        public string UserEmail { set; get; }
        public DateTime CreatedOn { set; get; }
    }
}
