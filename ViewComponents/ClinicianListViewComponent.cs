using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class ClinicianListViewComponent : ViewComponent
    {
        private IClinicianData _clinicianData;
        private IUserService _userService;

        public ClinicianListViewComponent(IClinicianData clinicianData, IUserService userService)
        {
            _clinicianData = clinicianData;
            _userService = userService;
        }
        public IViewComponentResult Invoke()
        {
            var model = new ClinicianViewModel();
            var clinicians = _clinicianData.GetListAsync().Result;
            model.UserId = _userService.GetCurrentUserId();
            model.UserName = _userService.GetCurrentUserName();
            model.Clinicians = clinicians;
            return View("ClinicianList", model);
        }
    }
}
