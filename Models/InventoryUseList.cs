using System.Collections.Generic;

namespace PARiConnect.MVCApp.Models
{
    public class InventoryUseList
    {
        public string ProductName { get; set; }
       
        public List<InventoryUse> InventoryUses { get; set; }

    }
}