using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IInventoryUsesData
    {
       Task<IEnumerable<InventoryUse>> GetAllAsync();
        Task<IEnumerable<InventoryUseList>> GetListAsync();
        IEnumerable<InventoryUse> GetAll();
    }
}
