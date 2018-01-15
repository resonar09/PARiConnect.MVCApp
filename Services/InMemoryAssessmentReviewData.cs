using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class InMemoryAssessmentReviewData : IAssessmentReviewData
    {
        public InMemoryAssessmentReviewData()
        {
            _assessmentReviews = new List<AssessmentReview>
            {
                new AssessmentReview {
                    ClientName ="Sam Smith",
                    Assessment = "CAB Parent Form",
                    Updated = "12/12/2016",
                    Status = "Completed"
                },
                new AssessmentReview {
                    ClientName ="Liz Evins",
                    Assessment = "CAD Self Form",
                    Updated = "12/08/2017",
                    Status = "Completed"
                },
                new AssessmentReview {
                    ClientName ="Sam Smith",
                    Assessment = "Brief Student Form",
                    Updated = "12/22/2017",
                    Status = "Completed"
                }
            };
        }
        public IEnumerable<AssessmentReview> GetAll()
        {
            return _assessmentReviews.OrderBy(x => x.Assessment);
        }
        List<AssessmentReview> _assessmentReviews;
    }
}
