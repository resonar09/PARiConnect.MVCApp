using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IInventoryData
    {
       Task<IEnumerable<InventoryUse>> GetAllInventoryUse();
       Task<IEnumerable<InventoryUseList>> GetInventoryUseListAsync();
       Task<IEnumerable<CoreServiceDevReference.AssessmentInventoryItem>> GetAssessmentListAsync();
       Task<bool> IsInventoryLow();

       Task<bool> SetFavoriteStatus(int assessmentFormKey, bool favorited);
       Task<bool> IsDistributable();
       Task<IEnumerable<InventoryUseList>> GetUndistributedListAsync();

    }
}
