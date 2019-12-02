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
        private readonly AppDBContext _appDBContext;

        public HomeController(ILogger<HomeController> logger, IResultRepository resultRepository, AppDBContext appDBContext)
        {
            _logger = logger;
            _resultRepository = resultRepository;
            _appDBContext = appDBContext;
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
            AppDBContext _appDBContext = new AppDBContext();
            List<Course> courses = _appDBContext.Courses.ToList();
            
            courses.Insert(0, new Course());
            

            if (ModelState.IsValid)
            {
                Result newResult = _resultRepository.Add(result);
                return RedirectToAction("resultSheet", new { Id = newResult.Id });
            }
            return View();
        }
        [HttpPost]
        public JsonResult InsertCourse(Course course)
        {
            using(AppDBContext _appDBContext = new AppDBContext())
            {
                _appDBContext.Courses.Add(course);
                _appDBContext.SaveChanges();
            }
            return Json(course);
        }
        [HttpPost]
        public IActionResult UpdateCourse(Course course)
        {
            using (AppDBContext _appDBContext = new AppDBContext())
            {
                Course updatedCourse = _appDBContext.Courses.Where(CSn => CSn.Sn == course.Sn).FirstOrDefault();
                updatedCourse.Name = course.Name;
                updatedCourse.Unit = course.Unit;
                updatedCourse.Grade = course.Grade;
                _appDBContext.SaveChanges();
            }
            return new EmptyResult();
        }

        [HttpPost]
        public IActionResult DeleteCourse(int sn)
        {
            using (AppDBContext _appDBContext = new AppDBContext())
            {
                Course course = _appDBContext.Courses.Where(CSn => CSn.Sn == sn).FirstOrDefault();
                _appDBContext.Courses.Remove(course);
                _appDBContext.SaveChanges();
            }
            return new EmptyResult();
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
