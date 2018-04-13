using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class ClientDetailViewModel
    {
        public int AssessmentFormKey { get; set; }
        public string AssessmentKey { get; set; }

        public string AssessmentFormName { get; set; }
        public int ReportFormKey { get; set; }

        public string ReportFormName { get; set; }

        public int ReportKey { get; set; }

        public IEnumerable<Report> Reports { get; set; }
    }
}