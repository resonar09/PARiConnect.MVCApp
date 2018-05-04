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
    public class InventoryData : IInventoryData
    {

        private IConfiguration _configuration;
        private IUserService _userService;
        public InventoryData(IConfiguration configuration, IUserService userService)
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

        public async Task<bool> IsDistributable()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var distributableInventory = await coreServiceClient.GetDistributableInventoryForUserAsync(int.Parse(loggedInUserID),false);
            return distributableInventory.Any();

        }
        public async Task<IEnumerable<InventoryUse>> GetAllInventoryUse()
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


        public async Task<IEnumerable<InventoryUseList>> GetInventoryUseListAsync()
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

           var distributableInventory = await coreServiceClient.GetDistributableInventoryForUserAsync(int.Parse(loggedInUserID),false);
            List<InventoryUseList> distributableInventoryList = new List<InventoryUseList>();
            foreach(var inv in distributableInventory)
            {
                var invUseList = new InventoryUseList(); 
                List<InventoryUse> inventoryUseList = new List<InventoryUse>();
                foreach(var assForms in inv.AssessmentForms){
                   
                    invUseList.ProductName = assForms.ProductFamily;
                    foreach(var reportForm in assForms.ReportForms){
                        var invUse = new InventoryUse();
                        invUse.ProductName = assForms.ProductFamily;
                        invUse.Name = reportForm.Name;
                        invUse.Uses = reportForm.Count;
                        inventoryUseList.Add(invUse);
                    }
                    invUseList.InventoryUses = inventoryUseList;
                    distributableInventoryList.Add(invUseList);
                }  
            }
            return distributableInventoryList;
        }

        public async Task<IEnumerable<CoreServiceDevReference.AssessmentInventoryItem>> GetAssessmentListAsync()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var assessments = await coreServiceClient.GetCurrentInventoryForUserAsync(int.Parse(loggedInUserID));
            var favorites = await coreServiceClient.GetFavoriteInventoryForCurrentUserAsync(int.Parse(loggedInUserID));

            //var fav = favorites.Where(x=>x.)
            var assessment = new Models.Assessment();

            
            var assessmentInventoryItems = assessments.Select(x => new CoreServiceDevReference.AssessmentInventoryItem
            {
                AssessmentKey = x.AssessmentKey,
                ProductFamily = x.ProductFamily,
                Count = x.Count,
                AssessmentForms = x.AssessmentForms
            });

            return assessmentInventoryItems;
        }

        public async Task<bool> SetFavoriteStatus(int assessmentFormKey, bool favorited)
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            try
            {
                await coreServiceClient.SetFavoriteStatusAsync(int.Parse(loggedInUserID), assessmentFormKey, favorited);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
