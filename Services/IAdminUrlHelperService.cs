using CoreServiceDevReference;
using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IAdminUrlHelperService
    {
       Task<OrgUserServiceDevReference.CustomerEmail> GetMessageTemplateByKeyAsync(int id);
       Task<CoreServiceDevReference.ServiceValidationResult> SendMailMessage(Message message, string emailMessageType);

    }
}
