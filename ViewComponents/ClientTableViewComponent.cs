using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class ClientTableViewComponent : ViewComponent
    {
        private IClientData _clientData;

        public ClientTableViewComponent(IClientData clientData)
        {
            _clientData = clientData;
        }
        public IViewComponentResult Invoke()
        {
            var model = new ClientViewModel();
            var clients = _clientData.GetListAsync().Result;
            model.Clients = clients;
            return View("ClientTable", model);
        }
    }
}
