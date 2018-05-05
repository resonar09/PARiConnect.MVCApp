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
    public class PermissionDataMock : IPermissionData
    {
        private IUserService _userService;
        List<OrgUserServiceDevReference.PermissionProfile> _permissionProfileList;
        List<OrgUserServiceDevReference.Permission> _permissionList;
        List<Models.PermissionProfileDefaultPerm> _permDefaultList;
        public PermissionDataMock(IUserService userService)
        {
             _userService = userService;
            _permissionProfileList = new List<OrgUserServiceDevReference.PermissionProfile>
            {
                new OrgUserServiceDevReference.PermissionProfile {
                    
                    PermissionProfileKey = 1,
                    PermissionProfileName = "PermissionProfile1"
                },
                new OrgUserServiceDevReference.PermissionProfile {
                    
                    PermissionProfileKey = 2,
                    PermissionProfileName = "PermissionProfile2"
                },
                new OrgUserServiceDevReference.PermissionProfile {
                    
                    PermissionProfileKey = 3,
                    PermissionProfileName = "PermissionProfile3"
                }
            };
             _permissionList = new List<OrgUserServiceDevReference.Permission>
            {
                new OrgUserServiceDevReference.Permission {
                    PermissionID = "1",
                    PermissionKey = 1,
                    PermissionName = "Permission1"
                },
                new OrgUserServiceDevReference.Permission {
                    PermissionID = "2",
                    PermissionKey = 2,
                    PermissionName = "Permission2"
                },
                new OrgUserServiceDevReference.Permission {
                    PermissionID = "3",
                    PermissionKey = 3,
                    PermissionName = "Permission3"
                }
            };
            _permDefaultList = new List<Models.PermissionProfileDefaultPerm>
            {
                        new Models.PermissionProfileDefaultPerm {
                            PermissionProfileDefaultPermKey = 1,
                            PermissionID = "1",
                            PermissionKey = 1,
                            PermissionParameterValue = 1,
                            PermissionProfileKey = 1
                        },
                        new Models.PermissionProfileDefaultPerm {
                            PermissionProfileDefaultPermKey = 2,
                            PermissionID = "2",
                            PermissionKey = 2,
                            PermissionParameterValue = 2,
                            PermissionProfileKey = 2
                        }

            };
        }
        
        public async Task<IEnumerable<OrgUserServiceDevReference.PermissionProfile>> GetPermissionProfileListAsync()
        {
            return await Task.Run(() => _permissionProfileList);
        }
        public async Task<IEnumerable<OrgUserServiceDevReference.Permission>> GetPermissionListAsync()
        {
            return await Task.Run(() => _permissionList.Where(x=>x.PermissionKey != 1));
        }
        public async Task<IEnumerable<Models.PermissionProfileDefaultPerm>> GetDefaultPermissionsAsync(int key)
        {
            
            return await Task.Run(() => _permDefaultList);
        }
        public async Task<int> GetPermissionByIdAsync(string id){
            return await Task.Run(() => _permissionList.Where(x=>x.PermissionID == id).Select(i=>i.PermissionKey).Single());
        }
    }
}

