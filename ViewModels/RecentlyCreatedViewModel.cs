using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class RecentlyCreatedViewModel
    {
        public IEnumerable<RecentlyCreated> RecentlyCreated { get; set; }
    }
}