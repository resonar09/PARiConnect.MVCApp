using PARiConnect.MVCApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System;

namespace PARiConnect.MVCApp.Services
{
    public class RecentlyAccessedData : IRecentlyAccessedData
    {
        private IHttpContextAccessor _httpAccessor;
        public RecentlyAccessedData(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }

        public IEnumerable<RecentlyAccessed> GetRecentlyAccessed()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<RecentlyAccessed>> GetRecentlyAccessedAsync()
        {
            var loggedInUser = _httpAccessor.HttpContext.User;
            var loggedInUserName = loggedInUser.Identity.Name;
            var loggedInUserID = loggedInUser.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid).Value;

            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientAssessmentReviews = await coreServiceClient.GetClientAssessmentsForReview_NEWAsync(null, int.Parse(loggedInUserID), null, null);

            var clientAssesReviews = clientAssessmentReviews
                .Select(x => new RecentlyAccessed
                {
                    Assessment = x.AssessmentForm.Assessment.Name + " " + x.AssessmentForm.Name,
                    ClientName = x.Client.FirstName + " " + x.Client.LastName,
                    Updated = x.ModifiedDateTime??DateTime.MinValue,
                }).OrderByDescending(x => x.Updated);
            return clientAssesReviews.GroupBy(c => c.ClientId, c => c.ClientName).Select(x=> new RecentlyAccessed{
                ClientId = x.Key,
                ClientName = x.First()
            });
        }

    }
}
