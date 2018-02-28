using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string TableId { get; set; }
        public IEnumerable<AssessmentReview> AssessmentReview { get; set; }
    }
}