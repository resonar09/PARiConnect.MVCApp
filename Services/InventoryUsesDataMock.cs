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
    public class InventoryUsesDataMock : IInventoryUsesData
    {
        List<InventoryUseList> _inventoryUseList;
        public InventoryUsesDataMock()
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
        }

        public async Task<IEnumerable<InventoryUseList>> GetListAsync()
        {
            return await Task.Run(() => _inventoryUseList);
        }

        public Task<bool> IsInventoryLow()
        {
            return Task.Run(() => _inventoryUseList.Any(x => x.InventoryUses.Any(u => u.Uses < 6)));
        }

        Task<IEnumerable<InventoryUse>> IInventoryUsesData.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
