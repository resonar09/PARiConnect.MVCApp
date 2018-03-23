using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models
{
    public class Report
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ReportName { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int ReportKey { get; set; }
        public string ReportLink { get; set; }

    }
}
