using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSK.BusinessLayer.Interfaces;
using JSK.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace JSK.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService TestService;
        private readonly IUserService UserService;
        public HomeController(ITestService testService, IUserService userService)
        {
            TestService = testService;
            UserService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomeModel model = new HomeModel();

            model.Tests = await TestService.Test_ListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HomeModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            int id = await UserService.CreateUser(new BusinessLayer.DTO.UserDTO() { Email = model.Email, Name = model.Name });

            return RedirectToAction("Test", new { id = Guid.NewGuid() });
        }

        public async Task<IActionResult> Test(Guid id)
        {
            return View();
        }
    }
}