using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class ClientEditViewComponent : ViewComponent
    {
        private readonly IClientData _clientData;
        private readonly IMapper _iMapper;
        public ClientEditViewComponent(IClientData clientData, IMapper iMapper)
        {
            _iMapper = iMapper;
            _clientData = clientData;
        }

        public IViewComponentResult Invoke(int id)
        {
            var client = _clientData.GetByKeyAsync(id).Result;
            if(client != null){
                var clientMap = _iMapper.Map<Models.Client>(client);
                return View("ClientEdit", clientMap);
            }
           return Content("No Data Exists");

        }
    }
}
