﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index(int? id)
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
