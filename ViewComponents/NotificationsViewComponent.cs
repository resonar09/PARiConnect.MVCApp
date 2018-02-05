using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class NotificationsViewComponent : ViewComponent
    {
        private IInventoryUsesData _inventoryUsesData;

        public NotificationsViewComponent(IInventoryUsesData inventoryUsesData)
        {
            _inventoryUsesData = inventoryUsesData;
        }
        public IViewComponentResult Invoke()
        {
            var model = new NotificationsViewModel();
            model.IsInventoryLow = _inventoryUsesData.IsInventoryLow().Result;
            return View("Notifications", model);
        }
    }
}
