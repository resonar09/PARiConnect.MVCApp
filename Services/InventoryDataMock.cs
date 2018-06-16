using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using CoreServiceDevReference;

namespace PARiConnect.MVCApp.Services
{
    public class InventoryDataMock : IInventoryData
    {
        List<InventoryUseList> _inventoryUseList;
        List<AssessmentInventoryItem> _assessmentInventoryItems;
        public InventoryDataMock()
        {
             _inventoryUseList = new List<InventoryUseList>
            {
                new InventoryUseList {
                    ProductName = "AAB",
                    InventoryUses = new List<InventoryUse>(){
                        new InventoryUse("Score Report", 4)
                        }
                        

                }
            };
            _assessmentInventoryItems = new List<AssessmentInventoryItem>()
            {
                new AssessmentInventoryItem {
                AssessmentKey = "CAD",
                ProductFamily = "CAD",
                Count = 12,
                AssessmentForms =  new AssessmentFormInventoryItem[] {
                    new AssessmentFormInventoryItem
                    {
                        AssessmentKey = "CAD",
                        PartNumber = "12345",
                        ProductFamily = "CAD",
                        Name = "Rating Form",

                    }


                }
                }
            };
        }

        public async Task<IEnumerable<AssessmentInventoryItem>> GetAssessmentListAsync()
        {
            return await Task.Run(() => _assessmentInventoryItems);
        }

        public async Task<IEnumerable<InventoryUseList>> GetInventoryUseListAsync()
        {
            return await Task.Run(() => _inventoryUseList);
        }

        public async Task<IEnumerable<InventoryUseList>> GetUndistributedListAsync()
        {
           return await Task.Run(() => _inventoryUseList);
        }

        public Task<bool> IsDistributable()
        {
            return Task.Run(() => _inventoryUseList.Any());
        }

        public Task<bool> IsInventoryLow()
        {
            return Task.Run(() => _inventoryUseList.Any(x => x.InventoryUses.Any(u => u.Uses < 6)));
        }

        public Task<bool> SetFavoriteStatus(int assessmentFormKey, bool favorited)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<InventoryUse>> IInventoryData.GetAllInventoryUse()
        {
            throw new NotImplementedException();
        }
    }
}
