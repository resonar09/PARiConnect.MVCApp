using PARiConnect.MVCApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace PARiConnect.MVCApp.Services
{
    public class RecentlyCreatedDataMock : IRecentlyCreatedData
    {
        private readonly IAssessmentReviewData _assessmentReview;

        public RecentlyCreatedDataMock(IAssessmentReviewData assessmentReview)
        {
            _assessmentReview = assessmentReview;
        }

        public IEnumerable<RecentlyAccessed> GetRecentlyAccessed()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RecentlyCreated> GetRecentlyCreated()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<RecentlyCreated>> GetRecentlyCreatedAsync()
        {
                var assessmentReview = await _assessmentReview.GetAllAsync(null);
                
                var grouped = assessmentReview.GroupBy(g => new{g.ClientId, g.ClientName}).Select(x => new RecentlyCreated
                {
                    ClientId = x.Key.ClientId,
                    ClientName = x.Key.ClientName,
                    Created = x.Max(d => d.Created)
                });
                              
                return grouped.OrderByDescending(o => o.Created).ToList().Take(6);
        }

    }
}
