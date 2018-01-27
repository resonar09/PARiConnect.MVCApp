using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class RecentlyAccessedViewModel
    {
        public IEnumerable<RecentlyAccessed> RecentlyAccessed { get; set; }
    }
}