using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class AssessmentReviewViewComponent : ViewComponent
    {
        private IAssessmentReviewData _assessmentReviewData;

        public AssessmentReviewViewComponent(IAssessmentReviewData assessmentReviewData)
        {
            _assessmentReviewData = assessmentReviewData;
        }
        public IViewComponentResult Invoke(bool completed)
        {
            var model = new HomeIndexViewModel();
            var assessmentReviews = _assessmentReviewData.GetAllAsync().Result;
            model.AssessmentReview = assessmentReviews.Where(x => x.Completed == completed);
            return View("AssessmentReview", model);
        }
    }
}
