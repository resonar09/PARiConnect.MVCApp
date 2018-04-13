using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace PARiConnect.MVCApp.Services
{
    public class AssessmentReviewData : IAssessmentReviewData
    {
        private IUserService _userService;
        public AssessmentReviewData(IUserService userService)
        {
             _userService = userService;
        }
        public async Task<IEnumerable<AssessmentReview>> GetAllAsync(int? clientKey)
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientAssessmentReviews = await coreServiceClient.GetClientAssessmentsForReview_NEWAsync(clientKey, int.Parse(loggedInUserID), null, null);
           // var clientAssessment = await coreServiceClient.GetClientAssessmentByKeyAsync();
            var clientAssesReviews = clientAssessmentReviews
                .Select(x => new AssessmentReview
                {
                    ClientAssessmentKey = x.ClientAssessmentKey,
                    ClientKey = x.ClientKey,
                    Assessment = x.AssessmentForm.Assessment.Name + " " + x.AssessmentForm.Name,
                    ClientName = x.Client.FirstName + " " + x.Client.LastName,
                    Updated = x.TestDate??DateTime.MinValue,//x.ModifiedDateTime??DateTime.MinValue,
                    StatusKey = x.StatusKey
                });
            return clientAssesReviews.OrderByDescending(x => x.Updated);
        }

        IEnumerable<AssessmentReview> IAssessmentReviewData.GetAll()
        {
            throw new System.NotImplementedException();
        }

    }
}
