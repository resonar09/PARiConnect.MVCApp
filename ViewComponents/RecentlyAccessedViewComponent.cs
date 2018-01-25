using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class RecentlyAccessedViewComponent : ViewComponent
    {
        private IAssessmentReviewData _assessmentReviewData;

        public RecentlyAccessedViewComponent(IAssessmentReviewData assessmentReviewData)
        {
            _assessmentReviewData = assessmentReviewData;
        }
        public IViewComponentResult Invoke(bool completed)
        {
            var model = new HomeIndexViewModel();
            var assessmentReviews = _assessmentReviewData.GetAllAsync().Result;
            model.AssessmentReview = assessmentReviews.Where(x => x.Completed == completed);
            return View("RecentlyAccessed", model);
        }
    }
}
