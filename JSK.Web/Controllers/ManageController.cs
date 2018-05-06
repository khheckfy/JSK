using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using JSK.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public IActionResult TestResults()
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
                if (obj.TestQuestions != null)
                    model.Questions = JsonConvert.SerializeObject(obj.TestQuestions);
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

                if (!string.IsNullOrEmpty(model.Questions))
                {
                    test.TestQuestions = JsonConvert.DeserializeObject<List<TestQuestionDTO>>(model.Questions);
                }

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

        public async Task<IActionResult> QuestionAnswers(int id)
        {
            QuestionAnswersModel model = new QuestionAnswersModel();

            var test = await TestService.Test_GetAsync(id);

            model.TestId = id;
            model.TestName = test.Name;
            model.Questions = test.TestQuestions;

            return View(model);
        }

        public async Task<JsonResult> Remove_Answer(int id)
        {
            string error = null;
            try
            {
                await TestService.Answer_RemoveAsync(id);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { error });
        }

        public async Task<JsonResult> IsCorrect_Answer(int id)
        {
            string error = null;
            try
            {
                await TestService.Answer_IsCorrect(id);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { error });
        }

        public async Task<JsonResult> Create_Answer(TestQuestionAnswerDTO model)
        {
            string error = null;
            int id = 0;
            var errorList = ModelState.Where(n => n.Value.Errors.Any()).ToDictionary(
                   kvp => kvp.Key,
                   kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
               );
            try
            {
                if (!ModelState.IsValid && errorList.Count > 0)
                    throw new Exception(string.Join(',', errorList.First().Value));

                id = await TestService.Answer_AddAsync(model);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Json(new { id, error, errorList });
        }
    }
}