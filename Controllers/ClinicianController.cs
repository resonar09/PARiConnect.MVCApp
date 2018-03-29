using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using CoreServiceDevReference;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Services;

namespace PARiConnect.MVCApp.Controllers
{
    [Authorize]

    public class ClinicianController : Controller
    {
        private readonly IUserService _userService;
        private readonly IClinicianData _clinicianData;
        private readonly IPermissionData _permissionData;
        private readonly IMessageService _messageService;
        private readonly IMapper _iMapper;

        public ClinicianController(IMapper iMapper, IUserService userService, IClinicianData clinicianData, 
        IPermissionData permissionData, IMessageService messageService)
        {
            _iMapper = iMapper;
            _clinicianData = clinicianData;
            _permissionData = permissionData;
            _messageService = messageService;
            _userService = userService;
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
        public IActionResult Invite(Models.Clinician model)
        {
            if (!ModelState.IsValid)
            {
                //return View("_Modal", "EditClient");
                var errors = ModelState
                    .SelectMany(x => x.Value.Errors, (y, z) => z.Exception.Message);

                return BadRequest(errors);

            }
            var orgUserMappingKey = int.Parse(_userService.GetCurrentUserId());
            var userName = _userService.GetCurrentUserName();
            var permList = new List<OrgUserServiceDevReference.OrgUserMappingPerm>();

            if(model.ACCESS_CLIENTS >= 0){
                var ACCESS_CLIENTS_KEY = _permissionData.GetPermissionByIdAsync("ACCESS_CLIENTS").Result; 
                var perm = new OrgUserServiceDevReference.OrgUserMappingPerm();
                perm.PermissionKey = ACCESS_CLIENTS_KEY;
                perm.OrgUserMappingKey = orgUserMappingKey;
                perm.PermissionParameterValue = model.ACCESS_CLIENTS;
                permList.Add(perm);
            }
            if(model.ACCESS_NEEDS_REVIEW >= 0){
                var ACCESS_NEEDS_REVIEW_KEY = _permissionData.GetPermissionByIdAsync("ACCESS_NEEDS_REVIEW").Result; 
                var perm = new OrgUserServiceDevReference.OrgUserMappingPerm();
                perm.PermissionKey = ACCESS_NEEDS_REVIEW_KEY;
                perm.OrgUserMappingKey = orgUserMappingKey;
                perm.PermissionParameterValue = model.ACCESS_NEEDS_REVIEW;
                permList.Add(perm);
            }
            if(model.ACCESS_REPORTS >= 0){
                var ACCESS_REPORTS_KEY = _permissionData.GetPermissionByIdAsync("ACCESS_REPORTS").Result; 
                var perm = new OrgUserServiceDevReference.OrgUserMappingPerm();
                perm.PermissionKey = ACCESS_REPORTS_KEY;
                perm.OrgUserMappingKey = orgUserMappingKey;
                perm.PermissionParameterValue = model.ACCESS_REPORTS;
                permList.Add(perm);
            }
            if(model.ALLOCATE_INVENTORY >= 0){
                var ALLOCATE_INVENTORY_KEY = _permissionData.GetPermissionByIdAsync("ALLOCATE_INVENTORY").Result; 
                var perm = new OrgUserServiceDevReference.OrgUserMappingPerm();
                perm.PermissionKey = ALLOCATE_INVENTORY_KEY;
                perm.OrgUserMappingKey = orgUserMappingKey;
                perm.PermissionParameterValue = model.ALLOCATE_INVENTORY;
                permList.Add(perm);                
            }
            if(model.ASSIGN_ASSESSMENTS >= 0){
                var ASSIGN_ASSESSMENTS_KEY = _permissionData.GetPermissionByIdAsync("ASSIGN_ASSESSMENTS").Result; 
                var perm = new OrgUserServiceDevReference.OrgUserMappingPerm();
                perm.PermissionKey = ASSIGN_ASSESSMENTS_KEY;
                perm.OrgUserMappingKey = orgUserMappingKey;
                perm.PermissionParameterValue = model.ASSIGN_ASSESSMENTS;
                permList.Add(perm);  
            }
            
            var orgUserInvitation = _clinicianData.InviteAsync(model.FirstName,model.LastName,model.EmailAddress,model.PermissionProfileId,permList.ToArray(),orgUserMappingKey).Result;
            string status = (orgUserInvitation != null) ? orgUserInvitation.OrgUserInvitationStatus : string.Empty;
            string picurl = "";

            if (status.Equals(InvitationStatusType.Invited, StringComparison.OrdinalIgnoreCase))
            {
                var customerEmail = _messageService.GetMessageTemplateByKeyAsync(1).Result;
                var message = new CoreServiceDevReference.Message();
                picurl = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host;
                string returnurl = string.Format("ReturnURL={0}/Login.aspx?EmailAddress={1}", picurl, orgUserInvitation.EmailAddress);
                string link = string.Format("{0}&orgUserInvitationKey={1}&VerificationKey={2}&{3}",
                                "/Register?iConnectInvitation=1",
                                orgUserInvitation.OrgUserInvitationKey,
                                orgUserInvitation.RowGUID.ToString().Substring(0, 8),
                                1 );

                string text = customerEmail.EmailText
                    .Replace("<FIRSTNAME />", orgUserInvitation.FirstName)
                    .Replace("<LASTNAME />", orgUserInvitation.LastName)
                    .Replace("<SUPERUSERNAME />", _userService.GetCurrentUserName())
                    .Replace("<INVITELINK />", link);
                message.Format = 0;
                message.Body = text;
                message.Subject = customerEmail.EmailSubject;
                message.From = new Recipient { Address = customerEmail.EmailFrom };
                message.To = new[] { new Recipient { Address = orgUserInvitation.EmailAddress } };   

                var messageResult = _messageService.SendMailMessage(message, EmailMessageType.OrgUserInvitation).Result;

                //return Ok(messageResult);
                return RedirectToAction("Index", "Home");
            }
 
            return Ok(picurl);

        }
    }
}
