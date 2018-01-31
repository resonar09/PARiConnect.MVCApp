using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models
{
    public sealed class StatusTypes
    {
        private readonly String name;
        private readonly int value;

        public static readonly StatusTypes PaperPencilEntryAssignedSavedAsDraft = new StatusTypes(3, "Not Completed");
        public static readonly StatusTypes PaperPencilEntryAssignedLaterVerification = new StatusTypes(4, "Not Completed");
        public static readonly StatusTypes PaperPencilEntryAssignedSavedNoReport = new StatusTypes(5, "Not Scored Yet");
        public static readonly StatusTypes PaperPencilEntryAssignedSavedReported = new StatusTypes(6, "Completed, Scored");
        public static readonly StatusTypes AdminEntryUnassignedPreviouslyExpired = new StatusTypes(7, "Expired");
        public static readonly StatusTypes AdminOnsiteEntryAssignedNotStarted = new StatusTypes(8, "Not Completed");
        public static readonly StatusTypes AdminOnsiteEntryAssignedStartedSuspended= new StatusTypes(9, "Not Completed");
        public static readonly StatusTypes AdminOnsiteEntryAssignedCompletedNoReport = new StatusTypes(10, "Not Scored Yet");
        public static readonly StatusTypes AdminOnsiteEntryAssignedCompletedInvalid = new StatusTypes(11, "Completed, Invalid");
        public static readonly StatusTypes AdminOnsiteEntryAssignedCompletedReport = new StatusTypes(12, "Completed, Scored");
        public static readonly StatusTypes AdminRemoteEntryAssignedNotStarted = new StatusTypes(13, "Not Completed");
        public static readonly StatusTypes AdminRemoteEntryAssignedExpired = new StatusTypes(14, "Expired");
        public static readonly StatusTypes AdminRemoteEntryAssignedSuspended = new StatusTypes(15, "Not Completed");
        public static readonly StatusTypes AdminRemoteEntryAssignedCompleteNoReport = new StatusTypes(16, "Not Scored Yet");
        public static readonly StatusTypes AdminRemoteEntryAssignedCompleteInvalid = new StatusTypes(17, "Completed, Invalid");
        public static readonly StatusTypes AdminRemoteEntryAssignedCompleteReport = new StatusTypes(18, "Completed, Scored");
        public static readonly StatusTypes PaperPencilEntryAssignedCompletedInvalid = new StatusTypes(19, "Completed, Invalid");
        public static readonly StatusTypes AdminOnsiteEntryAssignedAdjustmentsCSBI = new StatusTypes(20, "Not Completed");
        public static readonly StatusTypes AdminRemoteEntryAssignedAdjustmentsCSBI = new StatusTypes(21, "Not Completed");
        public static readonly StatusTypes AdminOnsiteEntryAssignedCompletedAdjustmentedCSBI = new StatusTypes(22, "Completed");
        public static readonly StatusTypes AdminRemoteEntryAssignedCompletedAdjustmentedCSBI = new StatusTypes(23, "Completed");


        private StatusTypes(int value, String name)
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
                case 6:
                case 12:
                    completed = true;
                    break;
                default:
                    completed = false;
                    break;
            }
            return completed;
        }


        public static List<int> GetCompletedStatuses(bool isCompleted)
        {
            List<int> statusList = new List<int>();
            if (isCompleted)
            {
               // statusList.Add(StatusTypes.PaperPencilEntryCompletedScored.value);
                //statusList.Add(StatusTypes.AdminOnsiteEntryCompletedScored.value);
            }
            else
            {
                //statusList.Add(StatusTypes.PaperPencilEntryIncomplete.value);
            }
            return statusList;
        }
    }
}
