using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class PermissionsViewComponent : ViewComponent
    {

        public PermissionsViewComponent()
        {

        
        }
        public IViewComponentResult Invoke()
        {
            //var model = new GroupViewModel();
            //var groups = _groupData.GetListAsync().Result;
            //model.Groups = groups;
            return View("Permissions");
        }
    }
}
