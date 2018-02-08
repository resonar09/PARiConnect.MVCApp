using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class ClinicianViewModel
    {
        public IEnumerable<Clinician> Clinicians { get; set; }
    }
}