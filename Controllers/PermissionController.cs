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

    public class PermissionController : Controller
    {
        private readonly IPermissionData _permissionData;
        private readonly IMapper _iMapper;

        public PermissionController(IMapper iMapper, IPermissionData permissionData)
        {
            _iMapper = iMapper;
            _permissionData = permissionData;
        }
        public IActionResult Index(int? id)
        {

            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetPermissions(string id)
        {
            var permissions = _permissionData.GetDefaultPermissionsAsync(int.Parse(id)).Result;
            return Ok(permissions);

        }
    }
}
