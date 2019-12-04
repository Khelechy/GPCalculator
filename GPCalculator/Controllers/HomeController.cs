using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GPCalculator.Models;
using GPCalculator.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace GPCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IResultRepository _resultRepository;
        

        public HomeController(ILogger<HomeController> logger, IResultRepository resultRepository)
        {
            _logger = logger;
            _resultRepository = resultRepository;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //[Route("Home/ResultSheet/{Lastname}")]
        public IActionResult ResultSheet(int? Id)
        {
            HomeResultSheetViewModel homeResultSheetViewModel = new HomeResultSheetViewModel()
            {
                Result = _resultRepository.GetResult(Id ?? 3),
            };
            return View(homeResultSheetViewModel);
            
        }
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(Result result)
        {
            if (ModelState.IsValid)
            {
                Result newResult = _resultRepository.Add(result);
                return RedirectToAction("resultSheet", new { Id = newResult.Id });
            }
            return View();
        }
        public IActionResult ResultList()
        {
            var model = _resultRepository.GetAllResult();
            return View(model);
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

   
}
