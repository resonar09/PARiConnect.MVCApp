using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class AssessViewModel
    {
        public IEnumerable<Client> Clients { get; set; }

        public IEnumerable<CoreServiceDevReference.AssessmentInventoryItem> Assessments { get; set; }
    }
}