using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class EditClientViewComponent : ViewComponent
    {
        private IInventoryUsesData _inventoryUsesData;

        public EditClientViewComponent(IInventoryUsesData inventoryUsesData)
        {
            _inventoryUsesData = inventoryUsesData;
        }
        public IViewComponentResult Invoke()
        {
            var model = new NotificationsViewModel();
            model.IsInventoryLow = _inventoryUsesData.IsInventoryLow().Result;
            model.IsDistributable = _inventoryUsesData.IsDistributable().Result;
            return View("EditClient", model);
        }
    }
}
