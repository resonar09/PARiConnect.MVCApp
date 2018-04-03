using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;

namespace PARiConnect.MVCApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAssessmentReviewData _assessmentReviewData;

        public HomeController(IAssessmentReviewData assessmentReviewData)
        {
            _assessmentReviewData = assessmentReviewData;
        }
        public async Task<IActionResult> Index()
        {
                var model = new HomeIndexViewModel();
                model.AssessmentReview = await _assessmentReviewData.GetAllAsync(null);
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
