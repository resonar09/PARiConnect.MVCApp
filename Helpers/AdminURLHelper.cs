using CoreServiceDevReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Helpers
{
    public static class AdminURLHelper
    {
        private static string _def_admin_url = "~/Instruments/CfgAssessment.aspx";

        public static string BuildAdminURL(ClientAssessment client_assessment, AssessmentForm assessment_form = null)
        {
            if (assessment_form == null)
                assessment_form = get_assessment_form(client_assessment.AssessmentFormKey);

            //return ((string.IsNullOrWhiteSpace(assessment_form.AdminURL)) ? _def_admin_url : assessment_form.AdminURL) + "?arg=" + client_assessment.UrlToken;
            return client_assessment.UrlToken;
        }

        public static string BuildAdminURL(DesktopAssessment desktop_assessment)
        {
            AssessmentForm assessment_form = (desktop_assessment.AssessmentForm == null)
                                                     ? get_assessment_form_for_class_id(desktop_assessment.DesktopClassID)
                                                     : desktop_assessment.AssessmentForm;

            return ((string.IsNullOrWhiteSpace(assessment_form.AdminURL)) ? _def_admin_url : assessment_form.AdminURL) + "?offline=" + desktop_assessment.UrlToken;
        }

        private static AssessmentForm get_assessment_form(int assessment_form_key)
        {
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            return coreServiceClient.GetAssessmentFormByKeyAsync(assessment_form_key).Result;

        }

        private static AssessmentForm get_assessment_form_for_class_id(string desktop_class_id)
        {
            ///TODO: Fix this core service function
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            return null;

            //var core_accessor = new CoreServiceAccessor();
           // return core_accessor.GetAssessmentFormByDesktopClass(desktop_class_id);
        }
    }
}
