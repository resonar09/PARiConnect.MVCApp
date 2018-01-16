using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Services;

namespace PARiConnect.MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAssessmentReviewData _assessmentReviewData;

        public HomeController(IAssessmentReviewData assessmentReviewData)
        {
            _assessmentReviewData = assessmentReviewData;
        }
        public IActionResult Index()
        {

            var model = _assessmentReviewData.GetAll();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
