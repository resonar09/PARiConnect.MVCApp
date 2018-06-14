using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using CoreServiceDevReference;

namespace PARiConnect.MVCApp.Services
{
    public class EmailData : IEmailData
    {
        private IUserService _userService;
        public EmailData(IUserService userService)
        {
             _userService = userService;
        }

        public async Task<bool> SendEmailMessage(Message message, string emailMessageType, int clientAssessmentKey)
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var emailTemplate = await coreServiceClient.GetEmailTemplatesByUserAsync(int.Parse(loggedInUserID));
            return true;
        }

        public async Task<IEnumerable<EmailTemplate>> GetEmailTemplateByUserAsync()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var emailTemplate = await coreServiceClient.GetEmailTemplatesByUserAsync(int.Parse(loggedInUserID));
            return emailTemplate;
        }

        public async Task<EmailTemplate> SaveOrUpdateEmailTemplateAsync(EmailTemplate emailTemplate)
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            emailTemplate.OrgUserMappingKey = int.Parse(loggedInUserID);
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var result = await coreServiceClient.SaveOrUpdateEmailTemplateAsync(emailTemplate);
            return result;
        }
    }

}

