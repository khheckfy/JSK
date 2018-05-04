using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JSK.Models;
using JSK.BusinessLayer.Interfaces;

namespace JSK.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService TestService;

        public HomeController(ITestService testService)
        {
            TestService = testService;
        }

        public IActionResult Index()
        {
            TestService.Test();
            return View();
        }
    }
}
