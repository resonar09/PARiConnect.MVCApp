using System;
using System.Collections.Generic;

namespace PARiConnect.MVCApp.Models
{
    public class Permission
    {
        public int PermissionKey{ get; set; }
        public string PermissionName { get; set; }
        public string PermissionID{ get; set; }

        public string PermissionOption{ get; set; }
    }
}