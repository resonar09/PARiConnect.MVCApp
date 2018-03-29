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

    public class GroupsController : Controller
    {
        private readonly IGroupData _groupData;
        private readonly IClientData _clientData;
        private readonly IMapper _iMapper;

        public GroupsController(IMapper iMapper, IGroupData groupData, IClientData clientData)
        {
            _iMapper = iMapper;
            _clientData = clientData;
            _groupData = groupData;
        }
        public IActionResult Index(int? id)
        {

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Models.Group model)
        {
            if (!ModelState.IsValid)
            {
                //return View("_Modal", "EditClient");
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors, (y, z) => z.Exception.Message);

                return BadRequest(errors);

            }
            model.ClientGroupKey = int.Parse(model.GroupId);

            var clientMap = _iMapper.Map<CoreServiceDevReference.ClientGroup>(model);
            var group = _groupData.SaveOrUpdate(clientMap);

            //return Ok(client);
            return RedirectToAction("Index", "Home");
        }
    }
}
