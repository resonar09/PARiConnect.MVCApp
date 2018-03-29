using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models
{
    public sealed class EmailMessageType
    {
        public const string RemoteAdminAssigned = "RemoteAdminAssigned";
        public const string ClientAssessmentReport = "ClientAssessmentReport";
        public const string OrgUserInvitation = "OrgUserInvitation";
        public const string NotifyOnAdminDone = "NotifyOnAdminDone";
        public const string FeedbackForm = "FeedbackForm";
        public const string RemoteAdminReminder = "RemoteAdminReminder";
        public const string DigitalDownloadLink = "DigitalDownloadLink";
    }

}
