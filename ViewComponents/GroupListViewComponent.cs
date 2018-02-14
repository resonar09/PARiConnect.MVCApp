using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class GroupListViewComponent : ViewComponent
    {
        private IGroupData _groupData;
        private IUserService _userService;

        public GroupListViewComponent(IGroupData groupData, IUserService userService)
        {
            _groupData = groupData;
            _userService = userService;
        }
        public IViewComponentResult Invoke()
        {
            var model = new GroupViewModel();
            var clinicians = _groupData.GetListAsync().Result;
            model.Groups = clinicians;
            return View("GroupList", model);
        }
    }
}
