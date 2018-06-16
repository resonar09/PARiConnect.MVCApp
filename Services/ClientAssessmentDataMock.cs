using CoreServiceDevReference;
using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class ClientAssessmentDataMock : IClientAssessmentData
    {
        //List<ClientAssessment> _clientAssessments;
        //private IAssessmentReviewData _assessmentReviewData;
        public ClientAssessmentDataMock(IAssessmentReviewData assessmentReviewData)
        {
            
        }

        public async Task<ClientAssessment> SaveClientAssessmentDemographics(ClientAssessment clientAssessment)
        {

            ///TODO: Convert clientAssessment to AssessmentReview
            AssessmentReview assessmentReview = new AssessmentReview();
            
            //return await _assessmentReviewData.AddAssessmentReview(assessmentReview).Result;
            clientAssessment.ClientAssessmentKey = 9999;
            return await Task.Run(() => clientAssessment);
        }
    }
}
