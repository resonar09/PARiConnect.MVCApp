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
        
        public async Task<IEnumerable<OrgUserServiceDevReference.PermissionProfile>> GetPermissionProfileListAsync()
        {
            OrgUserServiceDevReference.OrgUserServiceClient orgUserServiceClient = new OrgUserServiceDevReference.OrgUserServiceClient();
            var permissionProfileList = await orgUserServiceClient.GetPermissionProfileListAsync();
            //IEnumerable<OrgUserServiceDevReference.PermissionProfile> permissionProfilesResult = permissionProfiles.Cast<OrgUserServiceDevReference.PermissionProfile>();
            return permissionProfileList;
        }
        public async Task<IEnumerable<OrgUserServiceDevReference.Permission>> GetPermissionListAsync()
        {
            OrgUserServiceDevReference.OrgUserServiceClient orgUserServiceClient = new OrgUserServiceDevReference.OrgUserServiceClient();
            var permissionList = await orgUserServiceClient.GetPermissionListAsync();
            
            //IEnumerable<OrgUserServiceDevReference.PermissionProfile> permissionProfilesResult = permissionProfiles.Cast<OrgUserServiceDevReference.PermissionProfile>();
            return permissionList.Where(x=>x.PermissionKey != 1);
        }
        public async Task<IEnumerable<Models.PermissionProfileDefaultPerm>> GetDefaultPermissionsAsync(int key)
        {
            OrgUserServiceDevReference.OrgUserServiceClient orgUserServiceClient = new OrgUserServiceDevReference.OrgUserServiceClient();
            var defaultPermissionProfileList = await orgUserServiceClient.GetAllPermissionProfilesWithDefaultPermissionsAsync();
            var defaultPermissionList = defaultPermissionProfileList.Where(x=>x.PermissionProfileKey == key).Select(i=>i.PermissionProfileDefaultPerms);
            
            var permList = new List<Models.PermissionProfileDefaultPerm>();
            foreach(var defperms in defaultPermissionList){
                
                foreach(var perm in  defperms){
                    if(perm.PermissionKey > 1){
                        var permProfileDefaultPerm = new Models.PermissionProfileDefaultPerm();
                        permProfileDefaultPerm.PermissionProfileKey = key;
                        permProfileDefaultPerm.PermissionKey =  perm.PermissionKey;
                        permProfileDefaultPerm.PermissionID = perm.Permission.PermissionID;
                        permProfileDefaultPerm.PermissionParameterValue = perm.PermissionParameterValue;
                        permList.Add(permProfileDefaultPerm);
                    }

                }
            }
            return permList;
        }
        public async Task<int> GetPermissionByIdAsync(string id){
            OrgUserServiceDevReference.OrgUserServiceClient orgUserServiceClient = new OrgUserServiceDevReference.OrgUserServiceClient();
            var permissionList = await orgUserServiceClient.GetPermissionListAsync();
            return permissionList.Where(x=>x.PermissionID == id).Select(i=>i.PermissionKey).Single();
        }
    }
}

