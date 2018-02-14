using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class ClinicianViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Clinician> Clinicians { get; set; }
    }
}