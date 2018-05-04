using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;

namespace PARiConnect.MVCApp.Controllers
{
    [Authorize]
    public class AssessController : Controller
    {
        private readonly IInventoryData _inventoryData;

        private readonly IClientData _clientData;

        public AssessController(IInventoryData inventoryData, IClientData clientData)
        {
            _inventoryData = inventoryData;
            _clientData = clientData;
        }
        public IActionResult Index()
        {
            var model = new AssessViewModel();
            model.Clients = _clientData.GetClientGroupListAsync().Result;
            model.Assessments = _inventoryData.GetAssessmentListAsync().Result;
            return View(model);
        }
        public IActionResult Email()
        {
            //var model = new AssessViewModel();
            //model.Clients = _clientData.GetClientGroupListAsync().Result;
            //model.Assessments = _inventoryData.GetAssessmentListAsync().Result;
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
