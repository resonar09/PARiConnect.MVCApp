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
    public class RecentlyCreatedData : IRecentlyCreatedData
    {
         private IUserService _userService;
         private readonly IAssessmentReviewData _assessmentReview;
        public RecentlyCreatedData(IUserService userService,IAssessmentReviewData assessmentReview)
        {
            _userService = userService;
            _assessmentReview = assessmentReview;
        }

        public IEnumerable<RecentlyCreated> GetRecentlyCreated()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<RecentlyCreated>> GetRecentlyCreatedAsync()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientListResult = await coreServiceClient.GetClientListingForUserAsync(int.Parse(loggedInUserID));
            var clientList = clientListResult.Clients
                .Select(x => new RecentlyCreated
                {
                    ClientId = x.ClientKey,
                    ClientName = x.FirstName + " " + x.LastName,
                    Created = x.CreatedDateTime
                });
            return clientList.OrderByDescending(x => x.Created).Take(10);
        }

    }
}
