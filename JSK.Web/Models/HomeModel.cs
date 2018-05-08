using JSK.BusinessLayer.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "User name is empty")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Min length of name is 5, max 255")]
        public string Name { set; get; }

        public int TestId { set; get; }
        [Required(ErrorMessage = "Email is empty")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Min length of E-mail is 5, max 255")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
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
