using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PARiConnect.MVCApp.Helpers;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class InventoryViewComponent : ViewComponent
    {
        private IInventoryUsesData _inventoryUsesData;
        private IConfiguration _configuration;


        public InventoryViewComponent(IInventoryUsesData inventoryUsesData, IConfiguration configuration)
        {
            _inventoryUsesData = inventoryUsesData;
            _configuration = configuration;
        }
        public IViewComponentResult Invoke()
        {
            var model = new InventoryUseListViewModel();
            var invUses = _inventoryUsesData.GetListAsync().Result;
            model.InventoryUseList= invUses;

            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            model.InventoryLowThreshold = appSettings.InventoryLowThreshold;
            return View("Inventory", model);
        }
    }
}
