﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.Controllers
{
    [Authorize]
    public class AccountSettingsController : Controller
    {
        public IActionResult Index(int? id)
        {
            return View();
        }
        public IActionResult Labels(int? id)
        {
            return View();
        }
        public IActionResult DistributeUses(int? id)
        {
            return View();
        }
        public IActionResult AdditionalSettings(int? id)
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
