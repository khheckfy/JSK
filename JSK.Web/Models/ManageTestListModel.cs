using JSK.BusinessLayer.DTO;
using System.Collections.Generic;

namespace JSK.Web.Models
{
    public class ManageTestListModel
    {
        public ManageTestListModel()
        {
            Tests = new List<TestDTO>();
        }

        public List<TestDTO> Tests { set; get; }
    }
}
