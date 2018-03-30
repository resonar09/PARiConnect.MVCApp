using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Services;

namespace PARiConnect.MVCApp.Controllers
{
    [Authorize]

    public class ClientDetailController : Controller
    {
        private readonly IGroupData _groupData;
        private readonly IClientData _clientData;
        private readonly IMapper _iMapper;

        public ClientDetailController(IMapper iMapper, IGroupData groupData, IClientData clientData)
        {
            _iMapper = iMapper;
            _clientData = clientData;
            _groupData = groupData;
        }
        public IActionResult Index(int? id)
        {

            return View("Index", id);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Client model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors, (y, z) => z.Exception.Message);

                return BadRequest(errors);

            }
            var clientGroup = _groupData.GetByKeyAsync(int.Parse(model.GroupId)).Result;
            var clientMap = _iMapper.Map<CoreServiceDevReference.Client>(model);
            var client = _clientData.SaveOrUpdate(clientMap,clientGroup);

            return RedirectToAction("Index", "Clients");

        }
    }
}
