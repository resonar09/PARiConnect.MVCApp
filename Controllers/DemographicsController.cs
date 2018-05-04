﻿using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Services;

namespace PARiConnect.MVCApp.Controllers
{
    [Authorize]

    public class DemographicsController : Controller
    {

        private readonly IAssessmentFormData _assessmentFormData;
        public DemographicsController(IAssessmentFormData assessmentFormData)
        {
            _assessmentFormData = assessmentFormData;
        }
        public IActionResult Index(int? id)
        {
            return View();
        }
        public IActionResult GetDemo(int key)
        {
            var assessmentForm = _assessmentFormData.GetByKeyAsync(key).Result;

            return ViewComponent("DynamicForm", assessmentForm.AssessmentKey);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
