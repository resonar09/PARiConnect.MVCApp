using System;

namespace PARiConnect.MVCApp.Models
{
    public sealed class ClientAssessmentStatus
    {
        private readonly String name;
        private readonly int value;

        public static readonly ClientAssessmentStatus PaperPencilEntryAssignedSavedAsDraft = new ClientAssessmentStatus(3, "Not Completed");
        public static readonly ClientAssessmentStatus PaperPencilEntryAssignedLaterVerification = new ClientAssessmentStatus(4, "Not Completed");
        public static readonly ClientAssessmentStatus PaperPencilEntryAssignedSavedNoReport = new ClientAssessmentStatus(5, "Not Scored Yet");
        public static readonly ClientAssessmentStatus PaperPencilEntryAssignedSavedReported = new ClientAssessmentStatus(6, "Completed, Scored");
        public static readonly ClientAssessmentStatus AdminEntryUnassignedPreviouslyExpired = new ClientAssessmentStatus(7, "Expired");
        public static readonly ClientAssessmentStatus AdminOnsiteEntryAssignedNotStarted = new ClientAssessmentStatus(8, "Not Completed");
        public static readonly ClientAssessmentStatus AdminOnsiteEntryAssignedStartedSuspended= new ClientAssessmentStatus(9, "Not Completed");
        public static readonly ClientAssessmentStatus AdminOnsiteEntryAssignedCompletedNoReport = new ClientAssessmentStatus(10, "Not Scored Yet");
        public static readonly ClientAssessmentStatus AdminOnsiteEntryAssignedCompletedInvalid = new ClientAssessmentStatus(11, "Completed, Invalid");
        public static readonly ClientAssessmentStatus AdminOnsiteEntryAssignedCompletedReport = new ClientAssessmentStatus(12, "Completed, Scored");
        public static readonly ClientAssessmentStatus AdminRemoteEntryAssignedNotStarted = new ClientAssessmentStatus(13, "Not Completed");
        public static readonly ClientAssessmentStatus AdminRemoteEntryAssignedExpired = new ClientAssessmentStatus(14, "Expired");
        public static readonly ClientAssessmentStatus AdminRemoteEntryAssignedSuspended = new ClientAssessmentStatus(15, "Not Completed");
        public static readonly ClientAssessmentStatus AdminRemoteEntryAssignedCompleteNoReport = new ClientAssessmentStatus(16, "Not Scored Yet");
        public static readonly ClientAssessmentStatus AdminRemoteEntryAssignedCompleteInvalid = new ClientAssessmentStatus(17, "Completed, Invalid");
        public static readonly ClientAssessmentStatus AdminRemoteEntryAssignedCompleteReport = new ClientAssessmentStatus(18, "Completed, Scored");
        public static readonly ClientAssessmentStatus PaperPencilEntryAssignedCompletedInvalid = new ClientAssessmentStatus(19, "Completed, Invalid");
        public static readonly ClientAssessmentStatus AdminOnsiteEntryAssignedAdjustmentsCSBI = new ClientAssessmentStatus(20, "Not Completed");
        public static readonly ClientAssessmentStatus AdminRemoteEntryAssignedAdjustmentsCSBI = new ClientAssessmentStatus(21, "Not Completed");
        public static readonly ClientAssessmentStatus AdminOnsiteEntryAssignedCompletedAdjustmentedCSBI = new ClientAssessmentStatus(22, "Completed");
        public static readonly ClientAssessmentStatus AdminRemoteEntryAssignedCompletedAdjustmentedCSBI = new ClientAssessmentStatus(23, "Completed");

        private ClientAssessmentStatus(int value, String name)
        {
            this.name = name;
            this.value = value;
        }

        public override String ToString()
        {
            return name;
        }
        public static string GetStatus(int statusKey)
        {
            string status = "";
            switch (statusKey)
            {
                case 3:
                    status = StatusTypes.PaperPencilEntryAssignedSavedAsDraft.ToString();
                    break;
                case 4:
                    status = StatusTypes.PaperPencilEntryAssignedLaterVerification.ToString();
                    break;
                case 5:
                    status = StatusTypes.PaperPencilEntryAssignedSavedNoReport.ToString();
                    break;                    
                case 6:
                    status = StatusTypes.PaperPencilEntryAssignedSavedReported.ToString();
                    break;
                case 7:
                    status = StatusTypes.AdminEntryUnassignedPreviouslyExpired.ToString();
                    break;
                case 8:
                    status = StatusTypes.AdminOnsiteEntryAssignedNotStarted.ToString();
                    break;
                case 9:
                    status = StatusTypes.AdminOnsiteEntryAssignedStartedSuspended.ToString();
                    break;
                case 10:
                    status = StatusTypes.AdminOnsiteEntryAssignedCompletedNoReport.ToString();
                    break;
                case 11:
                    status = StatusTypes.AdminOnsiteEntryAssignedCompletedInvalid.ToString();
                    break;
                case 12:
                    status = StatusTypes.AdminOnsiteEntryAssignedCompletedReport.ToString();
                    break;
                case 13:
                    status = StatusTypes.AdminRemoteEntryAssignedNotStarted.ToString();
                    break;
                case 14:
                    status = StatusTypes.AdminRemoteEntryAssignedExpired.ToString();
                    break;
                case 15:
                    status = StatusTypes.AdminRemoteEntryAssignedSuspended.ToString();
                    break;
                case 16:
                    status = StatusTypes.AdminRemoteEntryAssignedCompleteNoReport.ToString();
                    break;
                case 17:
                    status = StatusTypes.AdminRemoteEntryAssignedCompleteInvalid.ToString();
                    break;
                case 18:
                    status = StatusTypes.AdminRemoteEntryAssignedCompleteReport.ToString();
                    break;
                case 19:
                    status = StatusTypes.PaperPencilEntryAssignedCompletedInvalid.ToString();
                    break;
                case 20:
                    status = StatusTypes.AdminOnsiteEntryAssignedAdjustmentsCSBI.ToString();
                    break;
                case 21:
                    status = StatusTypes.AdminRemoteEntryAssignedAdjustmentsCSBI.ToString();
                    break;
                case 22:
                    status = StatusTypes.AdminOnsiteEntryAssignedCompletedAdjustmentedCSBI.ToString();
                    break;
                case 23:
                    status = StatusTypes.AdminRemoteEntryAssignedCompletedAdjustmentedCSBI.ToString();
                    break;
                default:
                    status = "Not Completed";
                    break;
            }
            return status;
        }

        public static bool GetCompleted(int statusKey)
        {
            bool completed = true;
            switch (statusKey)
            {
                case 1:
                case 5:
                case 6:
                case 10:
                case 11:
                case 12:
                case 16:
                case 17:
                case 18:
                case 19:
                case 22:
                case 23:
                    completed = true;
                    break;
                default:
                    completed = false;
                    break;
            }
            return completed;
        }

        public static bool GetScored(int statusKey)
        {
            bool scored = false;
            switch (statusKey)
            {
                case 6:
                case 12:
                case 18:
                    scored = true;
                    break;
                default:
                    scored = false;
                    break;
            }
            return scored;
        }

    }
}