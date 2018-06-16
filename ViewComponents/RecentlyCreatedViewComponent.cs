using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class RecentlyCreatedViewComponent : ViewComponent
    {
        private IRecentlyCreatedData _recentlyCreatedData;

        public RecentlyCreatedViewComponent(IRecentlyCreatedData recentlyCreatedData)
        {
            _recentlyCreatedData = recentlyCreatedData;
        }
        public IViewComponentResult Invoke(bool completed)
        {
            var model = new RecentlyCreatedViewModel();
            model.RecentlyCreated = _recentlyCreatedData.GetRecentlyCreatedAsync().Result;
            return View("RecentlyCreated", model);
        }
    }
}
