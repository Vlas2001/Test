using System.Collections.Generic;
using System.Threading.Tasks;
using Dto.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Test;

namespace TestApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ITestService _testService;

        public HomeController(ITestService testService)
        {
            _testService = testService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestDescription()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var t = await _testService.GetRandomTest();
            return View(t);
        }
        
        [HttpPost]
        public IActionResult Test(IFormCollection val)
        {
            return View("Result", new UserAnswersDto()
            {
                Answers = new List<(string, string)>(_testService.Answers(val).Answers)
            });
        }
        
        public IActionResult SeedData()
        {
            _testService.Seed();
            return RedirectToAction("Index");
        }
    }
}