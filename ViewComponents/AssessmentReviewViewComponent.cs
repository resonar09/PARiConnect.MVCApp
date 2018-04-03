using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class AssessmentReviewViewComponent : ViewComponent
    {
        private IAssessmentReviewData _assessmentReviewData;

        public AssessmentReviewViewComponent(IAssessmentReviewData assessmentReviewData)
        {
            _assessmentReviewData = assessmentReviewData;
        }
        public IViewComponentResult Invoke(bool completed, int? clientKey)
        {
            var model = new HomeIndexViewModel();
            var assessmentReviews = _assessmentReviewData.GetAllAsync(clientKey).Result;
            model.AssessmentReview = assessmentReviews.Where(x => x.Completed == completed);
            model.TableId = (completed) ? "assessment-table-completed": "assessment-table-pending";
            return View("AssessmentReview", model);
        }
    }
}
