using PARiConnect.MVCApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class AssessmentReviewData : IAssessmentReviewData
    {
        List<AssessmentReview> _assessmentReviews;
        public AssessmentReviewData()
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
        public async Task<IEnumerable<AssessmentReview>> GetAllAsync()
        {
        
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientAssessmentReviews = await coreServiceClient.GetClientAssessmentsForReview_NEWAsync(null, 54338, null, null);

            var clientAssesReviews = clientAssessmentReviews
                .Select(x => new AssessmentReview
                {
                    Assessment = x.AssessmentForm.Assessment.Name + " " + x.AssessmentForm.Name,
                    ClientName = x.Client.FirstName + " " + x.Client.LastName,
                    Updated = x.TestDate.ToString(),
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
