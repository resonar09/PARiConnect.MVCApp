using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class ClientAssessTableViewComponent : ViewComponent
    {
        private IClientData _clientData;

        public ClientAssessTableViewComponent(IClientData clientData)
        {
            _clientData = clientData;
        }
        public IViewComponentResult Invoke(int[] keys)
        {
            var model = new ClientViewModel();
            var clients = _clientData.GetClientsByKeysAsync(keys).Result;
            model.Clients = clients;
            return View("ClientAssessTable", model);
        }
    }
}
