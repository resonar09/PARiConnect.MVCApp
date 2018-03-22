using System;
using System.Collections.Generic;

namespace PARiConnect.MVCApp.Models
{
    public class PermissionProfile
    {
        public int PermissionProfileKey{ get; set; }
        public string PermissionProfileName { get; set; }

        public int DisplayOrder { get; set; }
        public bool IsSuperUserProfile { get; set; }
        public bool IsEnterpriseManager { get; set; }
    }
}