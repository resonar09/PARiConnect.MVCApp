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

    public class ClientsController : Controller
    {
  
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
        public IActionResult Create(Models.Client model)
        {
            if (!ModelState.IsValid)
            {
                //return View("_Modal", "EditClient");
                return null;

            }
            return Json(model);
            
        }
    }
}
