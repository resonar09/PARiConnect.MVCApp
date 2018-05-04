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

    public class InventoryController : Controller
    {
        private readonly IInventoryData _inventoryData;
        private readonly IMapper _iMapper;

        public InventoryController(IMapper iMapper, IInventoryData inventoryData)
        {
            _iMapper = iMapper;
            _inventoryData = inventoryData;
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
        public IActionResult SetFavoriteStatus(int id, bool favorited)
        {
            var status = _inventoryData.SetFavoriteStatus(id,favorited).Result;
            return Ok(status);

        }
    }
}
