using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using CoreServiceDevReference;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;

namespace PARiConnect.MVCApp.Controllers
{
    [Authorize]

    public class EmailController : Controller
    {
        private readonly IEmailData _emailData;

        public EmailController(IEmailData emailData)
        {
            _emailData = emailData;
        }
        public IActionResult Index(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit([FromBody] IEnumerable<Models.Client> model)
        {
            if (ModelState.IsValid)
            {
                //var clientMap = _iMapper.Map<CoreServiceDevReference.Client>(model);
                //var clientRef = new CoreServiceDevReference.Client();
                //clientRef.ClientKey = model.ClientKey;
                //clientRef.ClientID = model.ClientId;

                //clientRef.DateOfBirth = !string.IsNullOrEmpty(model.DateOfBirth) ? DateTime.Parse(model.DateOfBirth) : (DateTime?) null;
                //if(!string.IsNullOrEmpty(model.Age) && int.Parse(model.Age) > 0)
                //{
                //    if (string.IsNullOrEmpty(model.DateOfBirth))
                //    {
                //        clientRef.DateOfBirthComputed = GetDateOfBirthCalcFromAge(int.Parse(model.Age));
                //    }
                //}
                //clientRef.FirstName = model.FirstName;
                /////TODO: Fix gender to not use string
                //if(model.Gender.ToUpper() == "2")
                //{
                //    clientRef.Gender = CoreServiceDevReference.Gender.Male;
                //}
                //else if (model.Gender.ToUpper() == "1")
                //{
                //    clientRef.Gender = CoreServiceDevReference.Gender.Female;
                //}
                //else
                //    clientRef.Gender = CoreServiceDevReference.Gender.NotSpecified;
                //clientRef.LastName = model.LastName;
                //clientRef.PrimaryEmail = model.PrimaryEmail;
                //var assessmentForm = _clientData.SaveOrUpdate(clientRef, null).Result;
            }
            return Content("completed");
        }


        public IActionResult GetEmailSettings()
        {
            return ViewComponent("EmailSettings");
        }
        [HttpPost]
        public IActionResult SaveEmailTemplate([FromBody] EmailTemplate emailData)
        {
            var emailTemplateResult = _emailData.SaveOrUpdateEmailTemplateAsync(emailData);
            return Content("Email template saved");
        }

        public EmailTemplate SaveOrUpdateEmailTemplates()
        {
            return new EmailTemplate();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public DateTime GetDateOfBirthCalcFromAge(int age)
        {
            DateTime today = new DateTime();
            DateTime dateOfBirthCalc = new DateTime();
            today = DateTime.Now;

            dateOfBirthCalc = today.AddYears(-1 * age);
            return dateOfBirthCalc;
        }

        
    }
}
