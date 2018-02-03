using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class InventoryViewComponent : ViewComponent
    {
        private IInventoryUsesData _inventoryUsesData;

        public InventoryViewComponent(IInventoryUsesData inventoryUsesData)
        {
            _inventoryUsesData = inventoryUsesData;
        }
        public IViewComponentResult Invoke()
        {
            var model = new InventoryUseListViewModel();
            var invUses = _inventoryUsesData.GetListAsync().Result;
            model.InventoryUseList= invUses;
            return View("Inventory", model);
        }
    }
}
