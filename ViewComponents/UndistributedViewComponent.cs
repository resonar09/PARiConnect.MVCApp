﻿using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;
using Microsoft.Extensions.Configuration;
using PARiConnect.MVCApp.Helpers;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class UndistributedViewComponent : ViewComponent
    {
        private IInventoryData _inventoryUsesData;
        private IConfiguration _configuration;


        public UndistributedViewComponent(IInventoryData inventoryUsesData, IConfiguration configuration)
        {
            _inventoryUsesData = inventoryUsesData;
            _configuration = configuration;
        }
        public IViewComponentResult Invoke()
        {
            var model = new InventoryUseListViewModel();
            var invUses = _inventoryUsesData.GetUndistributedListAsync().Result;
            model.InventoryUseList= invUses;

            var appSettingsSection = _configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            model.InventoryLowThreshold = appSettings.InventoryLowThreshold;
            return View("Undistributed", model);
        }
    }
}
