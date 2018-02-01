using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class InventoryViewComponent : ViewComponent
    {
        private IAssessmentReviewData _assessmentReviewData;

        public InventoryViewComponent(IAssessmentReviewData assessmentReviewData)
        {
            _assessmentReviewData = assessmentReviewData;
        }
        public IViewComponentResult Invoke()
        {

            return View("Inventory");
        }
    }
}
