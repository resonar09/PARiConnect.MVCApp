using System.Collections.Generic;
using CoreServiceDevReference;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class DemoInputViewModel
    {
        public int[] Assessments { get; set; }
        public int[] Clients { get; set; }
        public string[] ClientDataTable { get; set; }
        public string[] TestDataTable { get; set; }

    }
}