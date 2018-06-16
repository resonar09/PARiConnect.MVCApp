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

    public class DemographicsController : Controller
    {

        private readonly IAssessmentFormData _assessmentFormData;
        private readonly IClientAssessmentData _clientAssessmentData;
        //private readonly IEmailTemplateData _emailTemplateData;
        private readonly IMapper _iMapper;
        public DemographicsController(IMapper iMapper, IAssessmentFormData assessmentFormData, IClientAssessmentData clientAssessmentData)
        {
            _assessmentFormData = assessmentFormData;
            _clientAssessmentData = clientAssessmentData;
            _iMapper = iMapper;
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
        public IActionResult GetDemo(int key, int[] dataKeys, DisplayType? displayType)
        {
            var assessmentForm = _assessmentFormData.GetByKeyAsync(key).Result;
            var modelName = string.Format("{0}_{1}", assessmentForm.AssessmentKey, assessmentForm.AssessmentFormKey);

            return ViewComponent("DynamicForm", new { model = modelName, dataKeys, displayType });
        }
        [HttpPost]
        public IActionResult SaveDemoInput([FromBody]dynamic model) ///int[] assessments, int[] clients, string[] clientDataTable, string[] testDataTable)
        //public IActionResult SaveDemoInput(int[] assessments, int[] clients, string[] clientDataTable, string[] testDataTable)
        {
            //var test = model.assessments[0];
            ClientAssessment result = new ClientAssessment();
            for (var i = 0; i < model.clients.Count; i++)
            {
                //var test = model.clientDataTable.Count;
                var clientAssessment = new ClientAssessment
                {
                    ClientKey = model.clients[i],
                    AssessmentFormKey = model.assessments[0],
                    DataCaptureModeType = DataCaptureModeType.EmailNonBranded,
                    NotifyOnAdminDone = model.emailTemplateData.notify.Value,
                    ExpirationDays = 0,//model.emailTemplateData.expirationDays.Value,
                    StatusKey = 13,
                    ClientData = string.Join(",", model.clientDataTable[i]),
                    TestInfo = string.Join(",", model.testDataTable[i])
                };
                result = _clientAssessmentData.SaveClientAssessmentDemographics(clientAssessment).Result;
                if (result.ClientAssessmentKey > 0)
                {
                    var strategy = ClientAssessmentStrategyFactory
                    .GetClientAssessmentAdminStrategy(
                        result,
                        new
                        {
                            Body = model.emailTemplateData.template.Value,
                            IncludeProduct = model.emailTemplateData.product.Value,
                            IncludeAssessmentTime = model.emailTemplateData.assessmentTime.Value,
                            IncludeExpiration = model.emailTemplateData.expiration.Value,
                            ExpirationDays = model.emailTemplateData.expirationDays.Value,
                            Subject = model.emailTemplateData.subject.Value,
                            RaterEmail = model.clientDemoTable[i].primaryEmail.Value,
                            SendCopy = model.emailTemplateData.sendCopy.Value
                            //,OrgUserEmailAddress = "dperez@parinc.com"
                        });
                    strategy.Execute();
                }

            }

            return Json(new { someValue = "It's ok" });
        }
        public IActionResult SaveClientAssessment(int key)
        {
            var assessmentForm = _assessmentFormData.GetByKeyAsync(key).Result;

            return View();
        }
        public IActionResult GetEmailSettings()
        {
            //var assessmentForm = _assessmentFormData.GetByKeyAsync(key).Result;
            // var model = new EmailSettingsViewModel();
            //var emailTemplates = _emailTemplateData.GetByUserAsync().Result;
            //model.EmailTemplates = emailTemplates;
            return ViewComponent("EmailSettings");
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
