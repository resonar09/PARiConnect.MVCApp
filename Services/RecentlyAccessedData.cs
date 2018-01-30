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
         private readonly IAssessmentReviewData _assessmentReview;
        public RecentlyAccessedData(IHttpContextAccessor httpAccessor,IAssessmentReviewData assessmentReview)
        {
            _httpAccessor = httpAccessor;
            _assessmentReview = assessmentReview;
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


                var assessmentReview = await _assessmentReview.GetAllAsync();
                
                var grouped = assessmentReview.GroupBy(g => new{g.ClientId, g.ClientName}).Select(x => new RecentlyAccessed {
                    ClientId = x.Key.ClientId,
                    ClientName = x.Key.ClientName,
                    Updated = x.Max(d => d.Updated)
                });
                              
                return grouped.OrderByDescending(o => o.Updated).ToList().Take(10);
        }

    }
}
