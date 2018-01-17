using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class InMemoryAssessmentReviewData : IAssessmentReviewData
    {
        List<AssessmentReview> _assessmentReviews;
        public InMemoryAssessmentReviewData()
        {
            _assessmentReviews = new List<AssessmentReview>
            {
                new AssessmentReview {
                    ClientName ="Sam Smith",
                    Assessment = "CAB Parent Form",
                    Updated = "12/12/2016",
                     StatusKey = 6
                }, 
                new AssessmentReview {
                    ClientName ="Liz Evins",
                    Assessment = "CAD Self Form",
                    Updated = "12/08/2017",
                     StatusKey = 6
                },
                new AssessmentReview {
                    ClientName ="Mike Smith",
                    Assessment = "Brief Student Form",
                    Updated = "12/22/2017",
                     StatusKey = 6
                }
            };
        }
        public IEnumerable<AssessmentReview> GetAll()
        {
            return  _assessmentReviews.OrderBy(x => x.Assessment);
        }

        public async Task<IEnumerable<AssessmentReview>> GetAllAsync()
        {
            return await Task.Run(() => _assessmentReviews);
        }
    }
}
