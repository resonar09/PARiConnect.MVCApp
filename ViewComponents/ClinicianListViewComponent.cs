using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class ClinicianListViewComponent : ViewComponent
    {
        private IClinicianData _clinicianData;

        public ClinicianListViewComponent(IClinicianData clinicianData)
        {
            _clinicianData = clinicianData;
        }
        public IViewComponentResult Invoke()
        {
            var model = new ClinicianViewModel();
            var clinicians = _clinicianData.GetListAsync().Result;
            model.Clinicians = clinicians;
            return View("ClinicianList", model);
        }
    }
}
