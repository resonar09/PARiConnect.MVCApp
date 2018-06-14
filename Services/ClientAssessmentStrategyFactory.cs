using CoreServiceDevReference;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class ClientAssessmentStrategyFactory
    {
        public static IStrategy GetClientAssessmentAdminStrategy(ClientAssessment clientAssessment, dynamic args = null)
        {

            if (clientAssessment != null)
            {
                switch (clientAssessment.DataCaptureModeType)
                {
                    case DataCaptureModeType.Email:
                        {
                            var assessmentForm = GetAssessmentForm(clientAssessment.AssessmentFormKey);
                            //var clientAssessmentByEmailAdminStategy = new ClientAssessmentByEmailAdminStrategy();
                            return new ClientAssessmentByEmailAdminStrategy(clientAssessment, assessmentForm, args);
                        }
                    case DataCaptureModeType.EmailNonBranded:
                        {
                            var assessmentForm = GetAssessmentForm(clientAssessment.AssessmentFormKey);
                            return new ClientAssessmentByEmailAdminStrategy(clientAssessment, assessmentForm, args);
                        }
                    //case DataCaptureModeType.OnSite:
                    //    {
                    //        return new ClientAssessmentByOnSiteAdminStrategy(clientAssessment, args);
                    //    }
                    //case DataCaptureModeType.ManualEntry:
                    //    {
                    //        return new ClientAssessmentByManualEntryStrategy(clientAssessment);
                    //    }
                }
            }
            return null;
            //throw new ClientAssessmentAdministrationException("Unable to find a suitable strategy ");
        }

        private static AssessmentForm GetAssessmentForm(int assessmentFormKey)
        {
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            return coreServiceClient.GetAssessmentFormByKeyAsync(assessmentFormKey).Result;
        }
    }
}
