using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class RecentlyAccessedViewComponent : ViewComponent
    {
        private IRecentlyAccessedData _recentlyAccessedData;

        public RecentlyAccessedViewComponent(IRecentlyAccessedData recentlyAccessedData)
        {
            _recentlyAccessedData = recentlyAccessedData;
        }
        public IViewComponentResult Invoke(bool completed)
        {
            var model = new RecentlyAccessedViewModel();
            model.RecentlyAccessed = _recentlyAccessedData.GetRecentlyAccessedAsync().Result;
            return View("RecentlyAccessed", model);
        }
    }
}
