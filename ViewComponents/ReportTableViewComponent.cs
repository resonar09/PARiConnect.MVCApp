using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class ReportTableViewComponent : ViewComponent
    {
        private IReportData _reportData;

        public ReportTableViewComponent(IReportData reportData)
        {
            _reportData = reportData;
        }
        public IViewComponentResult Invoke()
        {
            var model = new ReportViewModel();
            var reports = _reportData.GetListAsync().Result;
            model.Reports = reports;
            return View("ReportTable", model);
        }
    }
}
