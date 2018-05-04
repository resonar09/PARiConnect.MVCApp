using System.Collections.Generic;

namespace PARiConnect.MVCApp.Models
{
    public class Assessment
    {
        public Assessment()
        {       
        }
        public string AssessmentKey { get; set; }
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public string ProductFamily { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }

        public List<AssessmentForm> AssessmentForms { get; set; }

    }
}