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
        private IHttpContextAccessor _httpAccessor;
        public AssessmentReviewData(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }
        public async Task<IEnumerable<AssessmentReview>> GetAllAsync()
        {
            var loggedInUser = _httpAccessor.HttpContext.User;
            var loggedInUserName = loggedInUser.Identity.Name;
            var loggedInUserID = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;

            //IEnumerable<Claim> claims = identity.Claims;
            // Get the claims values
            // var name = identity.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).Single(); 
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientAssessmentReviews = await coreServiceClient.GetClientAssessmentsForReview_NEWAsync(null, int.Parse(loggedInUserID), null, null);

            var clientAssesReviews = clientAssessmentReviews
                .Select(x => new AssessmentReview
                {
                    Assessment = x.AssessmentForm.Assessment.Name + " " + x.AssessmentForm.Name,
                    ClientName = x.Client.FirstName + " " + x.Client.LastName,
                    Updated = x.ModifiedDateTime??DateTime.MinValue,// : x.ModifiedDateTime,
                    StatusKey = x.StatusKey
                });
            return clientAssesReviews.OrderBy(x => x.Assessment);
        }

        IEnumerable<AssessmentReview> IAssessmentReviewData.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
