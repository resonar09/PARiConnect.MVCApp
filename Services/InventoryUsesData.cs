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
    public class InventoryUsesData : IInventoryUsesData
    {
        private IHttpContextAccessor _httpAccessor;
        public InventoryUsesData(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }


        public async Task<IEnumerable<InventoryUse>> GetAll()
        {
            var loggedInUser = _httpAccessor.HttpContext.User;
            var loggedInUserName = loggedInUser.Identity.Name;
            var loggedInUserID = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;

            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var inventoryUsesList = await coreServiceClient.GetCurrentInventoryForUserListAsync(int.Parse(loggedInUserID));

            var inventoryUses = inventoryUsesList
                .Select(x => new InventoryUse
                {
                    Name = x.Name,
                    ProductName = x.ProductName,
                    Uses = x.Uses 
                });
            return inventoryUses;
        }


        public async Task<IEnumerable<InventoryUseList>> GetListAsync()
        {
            var loggedInUser = _httpAccessor.HttpContext.User;
            var loggedInUserName = loggedInUser.Identity.Name;
            var loggedInUserID = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;

            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var inventoryUsesList = await coreServiceClient.GetCurrentInventoryForUserListAsync(int.Parse(loggedInUserID));

            var inventoryUses = inventoryUsesList.GroupBy(g => g.ProductName, g => new InventoryUse(g.Name,g.Uses), (key,g) => new InventoryUseList {
                    ProductName = key,
                    InventoryUses = g.ToList()
            });
/*                 .Select(x => new InventoryUseList
                {
                    ProductName = x.Key,
                    InventoryUses = new InventoryUse(x.Key.
                }); */
/*                 List<InventoryUse> invUse = new List<InventoryUse>();
                List<InventoryUseList> invUseList = new List<InventoryUseList>();
                foreach(var inv in inventoryUses){
                    invUse.Add(new InventoryUse(inv.Name,inv.Uses));

                } */
                
            return inventoryUses;
        }

    }
}
