using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class InventoryUseListViewModel
    {
        public IEnumerable<InventoryUseList> InventoryUseList { get; set; }
    }
}