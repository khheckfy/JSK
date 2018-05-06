using System;
using System.Threading.Tasks;
using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using JSK.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace JSK.Web.Controllers
{
    public class ManageController : Controller
    {
        private readonly ITestService TestService;
        public ManageController(ITestService testService)
        {
            TestService = testService;
        }

        public async Task<IActionResult> Index()
        {
            ManageTestListModel model = new ManageTestListModel();
            model.Tests = await TestService.Test_ListAsync();
            return View(model);
        }

        public async Task<IActionResult> TestResults()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TestForm(int? id)
        {
            ManageTestModel model = new ManageTestModel();
            if (id.HasValue)
            {
                var obj = await TestService.Test_GetAsync(id.Value);
                model.IsRandomQuestions = obj.IsRandomQuestionsOrder;
                model.TestId = id.Value;
                model.TestName = obj.Name;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TestForm(ManageTestModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                TestDTO test = new TestDTO()
                {
                    IsRandomQuestionsOrder = model.IsRandomQuestions,
                    Name = model.TestName,
                    TestId = model.TestId
                };

                await TestService.Test_SaveAsync(test);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> RemoveTest(int id)
        {
            string error = null;
            try
            {
                await TestService.Test_RemoveAsync(id);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { error });
        }
    }
}