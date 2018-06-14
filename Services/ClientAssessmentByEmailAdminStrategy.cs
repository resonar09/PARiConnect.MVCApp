using CoreServiceDevReference;
using Microsoft.AspNetCore.Http;
using PARiConnect.MVCApp.Helpers;
using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class ClientAssessmentByEmailAdminStrategy : IStrategy
    {
        private  CoreServiceDevReference.AssessmentForm _assessmentForm;
        private  ClientAssessment _clientAssessment;
        private  dynamic _args;

        public ClientAssessmentByEmailAdminStrategy(ClientAssessment clientAssessment, CoreServiceDevReference.AssessmentForm assessmentForm, dynamic args)
        {
            _clientAssessment = clientAssessment;
            _assessmentForm = assessmentForm;
            _args = args;

        }

        public void Execute()
        {
            //string url = _httpContextAccessor.HttpContext.Request.Scheme + _httpContextAccessor.HttpContext.Request.Host + _httpContextAccessor.HttpContext.Request.Path;
            //+ VirtualPathUtility.ToAbsolute(AdminURLHelper.BuildAdminURL(_clientAssessment, _assessmentForm));
            string url = "http://devwww.pariconnect.com/Instruments/CfgAssessment.aspx?arg=" + AdminURLHelper.BuildAdminURL(_clientAssessment, _assessmentForm);
            var sb = new StringBuilder();
            sb.AppendLine(_args.Body);

            if (_assessmentForm != null)
            {
                CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
                var assessment = coreServiceClient.GetAssessmentByKeyAsync(_assessmentForm.AssessmentKey).Result;
                if (_args.IncludeProduct)
                {
                    sb.AppendFormat("<p>Assessment: {0}</p>", assessment.Name);
                }
                if (_args.IncludeAssessmentTime
                    && _assessmentForm.EstimatedTime != null)
                {
                    sb.AppendFormat("<p>Time (minutes): {0}</p>", _assessmentForm.EstimatedTime);
                }
                if (_args.IncludeExpiration
                    && _args.ExpirationDays != null)
                {
                    sb.AppendFormat("<p>Expiration: {0} days.</p>", _args.ExpirationDays);
                }
                if (_args.IncludeProduct)
                    sb.AppendFormat("<p>Use this link to launch the Assessment: <a href=\"{0}\">Launch {1}</a></p>", url, assessment.Name);
                else
                    sb.AppendFormat("<p>Use this link to launch the Assessment: <a href=\"{0}\">Launch</a></p>", url);
                var message = new Message
                {
                    Body = sb.ToString(),
                    Format = Format.Html,
                    Subject = _args.Subject,
                    From = new Recipient { Address = "noreply@parinc.com" },   //ApplicationConfigurationHelper.EMailAdminLinkSender ?? "noreply@parinc.com" },
                    //ReplyTo = new Recipient[] { new Recipient { Address = _args.OrgUserEmailAddress } },
                    To = new[] { new Recipient { Address = _args.RaterEmail } } //, _args.RaterEmail } }
                };

                var sentMessage = coreServiceClient.SendMailMessageAsync(message, EmailMessageType.RemoteAdminAssigned.ToString(), _clientAssessment.OrgUserMappingKey.ToString(), _clientAssessment.ClientAssessmentKey, _clientAssessment.OrgUserMappingKey, null);
            }
        }
    }
}
