using JSK.BusinessLayer.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSK.Web.Models
{
    public class HomeModel
    {
        public HomeModel()
        {
            Tests = new List<TestDTO>();
        }

        public string Name { set; get; }
        public int TestId { set; get; }
        public string Email { set; get; }
        public IEnumerable<TestDTO> Tests { set; get; }

        public List<SelectListItem> TestListItems
        {
            get
            {
                return Tests.Select(n => new SelectListItem()
                {
                    Value = n.TestId.ToString(),
                    Text = n.Name
                }).ToList();
            }
        }
    }
}
