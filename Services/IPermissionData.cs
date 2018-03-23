using CoreServiceDevReference;
using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IPermissionData
    {
       Task<IEnumerable<OrgUserServiceDevReference.PermissionProfile>> GetPermissionProfileListAsync();

       Task<IEnumerable<OrgUserServiceDevReference.Permission>> GetPermissionListAsync();

       Task<IEnumerable<Models.PermissionProfileDefaultPerm>> GetDefaultPermissionsAsync(int key);
    }
}
