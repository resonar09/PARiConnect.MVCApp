using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class GroupListViewComponent : ViewComponent
    {
        private IGroupData _groupData;
        public GroupListViewComponent(IGroupData groupData)
        {
            _groupData = groupData;
        
        }
        public IViewComponentResult Invoke()
        {
            var model = new GroupViewModel();
            var groups = _groupData.GetListAsync().Result;
            model.Groups = groups;
            return View("GroupList", model);
        }
    }
}
