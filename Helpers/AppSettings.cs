using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public bool Offline { get; set; }

        public int InventoryLowThreshold { get; set; }
    }
}
