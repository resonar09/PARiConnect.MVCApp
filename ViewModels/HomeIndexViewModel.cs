using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<AssessmentReview> AssessmentReview { get; set; }
    }
}