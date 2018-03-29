using CoreServiceDevReference;
using OrgUserServiceDevReference;
using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{

    public class MessageService : IMessageService
    {
        public async Task<CustomerEmail> GetMessageTemplateByKeyAsync(int id)
        {
            OrgUserServiceDevReference.OrgUserServiceClient orgUserServiceClient = new OrgUserServiceDevReference.OrgUserServiceClient();
            var customerEmail = await orgUserServiceClient.GetCustomerEmailByKeyAsync(id);
            return customerEmail;
        }

        public async Task<CoreServiceDevReference.ServiceValidationResult> SendMailMessage(Message message, string emailMessageType)
        {
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var customerEmail = await coreServiceClient.SendMailMessageAsync(message,emailMessageType,"", null, null,null);
            return customerEmail;
        }
    }
}
