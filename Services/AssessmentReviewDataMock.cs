using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class AssessmentReviewDataMock : IAssessmentReviewData
    {
        List<AssessmentReview> _assessmentReviews;
        public AssessmentReviewDataMock()
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
                },
                new AssessmentReview {
                    ClientName ="Tab Johnson",
                    Assessment = "Spectra Form",
                    Updated = "1/12/2018",
                     StatusKey = 5
                },
                new AssessmentReview {
                    ClientName ="Chris Peterson",
                    Assessment = "Spectra Form",
                    Updated = "1/22/2018",
                     StatusKey = 5
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
