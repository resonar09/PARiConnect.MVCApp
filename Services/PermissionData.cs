using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
//using CoreServiceDevReference;

namespace PARiConnect.MVCApp.Services
{
    public class PermissionData : IPermissionData
    {
        private IUserService _userService;
        public PermissionData(IUserService userService)
        {
             _userService = userService;
        }
        
        public async Task<IEnumerable<OrgUserServiceDevReference.PermissionProfile>> GetPermissionProfilesAsync()
        {
            OrgUserServiceDevReference.OrgUserServiceClient orgUserServiceClient = new OrgUserServiceDevReference.OrgUserServiceClient();
            var permissionProfiles = await orgUserServiceClient.GetAllPermissionProfilesWithDefaultPermissionsAsync();
            IEnumerable<OrgUserServiceDevReference.PermissionProfile> permissionProfilesResult = permissionProfiles.Cast<OrgUserServiceDevReference.PermissionProfile>();
            return permissionProfilesResult;
        }


    }
}

