using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PARiConnect.MVCApp.Helpers;

namespace PARiConnect.MVCApp.Services
{
    public class InventoryUsesData : IInventoryUsesData
    {

        private IConfiguration _configuration;
        private IUserService _userService;
        public InventoryUsesData(IConfiguration configuration, IUserService userService)
        { 
            _userService = userService;
            _configuration = configuration;
        }

        public async Task<bool> IsInventoryLow()
        {
            var loggedInUserID = _userService.GetCurrentUserId();

            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var inventoryUsesList = await coreServiceClient.GetCurrentInventoryForUserListAsync(int.Parse(loggedInUserID));
            
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            var anyUsesLow = inventoryUsesList.Any(x => x.Uses < appSettings.InventoryLowThreshold);

            return anyUsesLow;
        }
        public async Task<IEnumerable<InventoryUse>> GetAll()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
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
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var inventoryUsesList = await coreServiceClient.GetCurrentInventoryForUserListAsync(int.Parse(loggedInUserID));

            var inventoryUses = inventoryUsesList.GroupBy(g => g.ProductName, g => new InventoryUse(g.Name,g.Uses), (key,g) => new InventoryUseList {
                    ProductName = key,
                    InventoryUses = g.ToList()
            });

            return inventoryUses;
        }
        public async Task<IEnumerable<InventoryUseList>> GetUndistributedListAsync()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var inventoryUsesList = await coreServiceClient.GetCurrentInventoryForUserListAsync(int.Parse(loggedInUserID));

            var inventoryUses = inventoryUsesList.GroupBy(g => g.ProductName, g => new InventoryUse(g.Name,g.Uses), (key,g) => new InventoryUseList {
                    ProductName = key,
                    InventoryUses = g.ToList()
            });

            return inventoryUses;
        }

    }
}
