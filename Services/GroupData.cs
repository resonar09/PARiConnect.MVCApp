using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace PARiConnect.MVCApp.Services
{
    public class GroupData : IGroupData
    {
        private IUserService _userService;
        public GroupData(IUserService userService)
        {
             _userService = userService;
        }
        
        public Task<IEnumerable<Group>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Group>> GetListAsync()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var groupListingForUser = await coreServiceClient.GetAllClientListingForUserAsync(int.Parse(loggedInUserID));

            var groupListing = groupListingForUser.ClientGroups
                .Select(x => new Group
                {
                   GroupId = x.ClientGroupKey,
                   GroupName = x.Name,
                   ClientCount = x.Clients.Count()
                //    ,
                //    Clients = x.Clients.ToList()
                });
            return groupListing;
        }

    }
}

