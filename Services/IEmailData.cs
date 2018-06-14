using CoreServiceDevReference;
using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IEmailData
    {
       Task<bool> SendEmailMessage(Message message, string emailMessageType, int clientAssessmentKey);
       Task<IEnumerable<EmailTemplate>> GetEmailTemplateByUserAsync();
       Task<EmailTemplate> SaveOrUpdateEmailTemplateAsync(EmailTemplate emailTemplate);
    }
}
