using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class ReportViewModel
    {
        public int ClinicianId { get; set; }
        public IEnumerable<Report> Reports { get; set; }
    }
}