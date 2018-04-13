using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class ClientReportsViewComponent : ViewComponent
    {
        private IClientData _clientData;

        public ClientReportsViewComponent(IClientData clientData)
        {
            _clientData = clientData;
        }
        public IViewComponentResult Invoke(int clientKey)
        {
            var model = new ClientDetailViewModel();
            var clients = _clientData.GetClientReportsAsync(clientKey).Result;
            model.Reports = clients;
            return View("ClientReports", model);
        }
    }
}
