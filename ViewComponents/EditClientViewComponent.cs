using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class EditClientViewComponent : ViewComponent
    {
        public EditClientViewComponent()
        {

        }
        public IViewComponentResult Invoke()
        {
            var model = new Client();
            //model.IsInventoryLow = _inventoryUsesData.IsInventoryLow().Result;
            //model.IsDistributable = _inventoryUsesData.IsDistributable().Result;
            return View("EditClient", model);
        }
    }
}
