using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSK.BusinessLayer.DTO;
using JSK.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSK.Controllers
{
    [Produces("application/json")]
    [Route("api/Tests")]
    public class TestsController : Controller
    {
        private readonly ITestService testService;

        public TestsController(ITestService service)
        {
            testService = service;
        }
        [HttpGet]
        public async Task<List<TestDTO>> Get()
        {
            return await testService.Test_List();
        }
    }
}