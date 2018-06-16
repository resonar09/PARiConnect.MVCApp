using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class AssessmentReviewDataMock : IAssessmentReviewData
    {
        public List<AssessmentReview> _assessmentReviews;
        public AssessmentReviewDataMock()
        {
            _assessmentReviews = new List<AssessmentReview>
            {
                new AssessmentReview {
                    ClientId = 1,
                    ClientName ="Sam Smith",
                    Assessment = "CAB Parent Form",
                    Updated = DateTime.Parse("12/12/2016"),
                    Created = DateTime.Parse("12/12/2016"),
                     StatusKey = 6
                }, 
                new AssessmentReview {
                    ClientId = 2,
                    ClientName ="Liz Evins",
                    Assessment = "CAD Self Form",
                    Updated = DateTime.Parse("12/08/2017"),
                    Created = DateTime.Parse("12/08/2017"),
                     StatusKey = 6
                },
                new AssessmentReview {
                    ClientId = 1,
                    ClientName ="Sam Smith",
                    Assessment = "CAB Parent Form",
                    Updated = DateTime.Parse("12/05/2016"),
                    Created = DateTime.Parse("12/05/2016"),
                     StatusKey = 13
                }, 
                new AssessmentReview {
                    ClientId = 2,
                    ClientName ="Liz Evins",
                    Assessment = "CAD Self Form",
                    Updated = DateTime.Parse("12/08/2017"),
                    Created = DateTime.Parse("12/08/2017"),
                     StatusKey = 13
                },
                new AssessmentReview {
                    ClientId = 3,
                    ClientName ="Mike Smith",
                    Assessment = "Brief Student Form",
                    Updated = DateTime.Parse("12/22/2017"),
                    Created = DateTime.Parse("12/22/2017"),
                     StatusKey = 6
                },
                new AssessmentReview {
                    ClientId = 4,
                    ClientName ="Tab Johnson",
                    Assessment = "Spectra Form",
                    Updated = DateTime.Parse("1/12/2018"),
                    Created = DateTime.Parse("1/12/2018"),
                     StatusKey = 5
                },
                new AssessmentReview {
                    ClientId = 5,
                    ClientName ="Chris Peterson",
                    Assessment = "Spectra Form",
                    Updated = DateTime.Parse("1/22/2018"),
                    Created = DateTime.Parse("1/22/2018"),
                     StatusKey = 5
                },
                                new AssessmentReview {
                    ClientId = 3,
                    ClientName ="Mike Smith",
                    Assessment = "Brief Student Form",
                    Updated = DateTime.Parse("12/22/2017"),
                    Created = DateTime.Parse("12/22/2017"),
                     StatusKey = 6
                },
                new AssessmentReview {
                    ClientId = 4,
                    ClientName ="Tab Johnson",
                    Assessment = "Spectra Form",
                    Updated = DateTime.Parse("1/12/2018"),
                    Created = DateTime.Parse("1/12/2018"),
                     StatusKey = 13
                },
                new AssessmentReview {
                    ClientId = 5,
                    ClientName ="Chris Peterson",
                    Assessment = "Spectra Form",
                    Updated = DateTime.Parse("1/22/2018"),
                    Created = DateTime.Parse("1/22/2018"),
                     StatusKey = 13
                },
                new AssessmentReview {
                    ClientId = 6,
                    ClientName ="Steve Crowder",
                    Assessment = "Brief Student Form",
                    Updated = DateTime.Parse("12/22/2017"),
                    Created = DateTime.Parse("12/22/2017"),
                     StatusKey = 13
                },
                new AssessmentReview {
                    ClientId = 7,
                    ClientName ="Dave Rubin",
                    Assessment = "AAB Standard From",
                    Updated = DateTime.Parse("1/12/2018"),
                    Created = DateTime.Parse("1/12/2018"),
                     StatusKey = 13
                },
                new AssessmentReview {
                    ClientId = 8,
                    ClientName ="Gavin McGinnis",
                    Assessment = "Spectra Form",
                    Updated = DateTime.Parse("1/22/2018"),
                    Created = DateTime.Parse("1/22/2018"),
                    StatusKey = 5
                },
                new AssessmentReview {
                    ClientId = 6,
                    ClientName ="Steve Crowder",
                    Assessment = "Brief Student Form",
                    Updated = DateTime.Parse("1/24/2017"),
                    Created = DateTime.Parse("1/24/2017"),
                     StatusKey = 6
                },
                new AssessmentReview {
                    ClientId = 6,
                    ClientName ="Steve Crowder",
                    Assessment = "Brief Student Form",
                    Updated = DateTime.Parse("1/24/2017"),
                    Created = DateTime.Parse("1/24/2017"),
                     StatusKey = 13
                },
                new AssessmentReview {
                    ClientId = 7,
                    ClientName ="Dave Rubin",
                    Assessment = "Spectra Form",
                    Updated = DateTime.Parse("1/25/2018"),
                    Created = DateTime.Parse("1/25/2018"),
                     StatusKey = 5
                },
                new AssessmentReview {
                    ClientId = 7,
                    ClientName ="Dave Rubin",
                    Assessment = "Spectra Form",
                    Updated = DateTime.Parse("1/25/2018"),
                    Created = DateTime.Parse("1/25/2018"),
                     StatusKey = 13
                },
                new AssessmentReview {
                    ClientId = 8,
                    ClientName ="Gavin McGinnis",
                    Assessment = "Spectra Form",
                    Updated = DateTime.Parse("1/26/2018"),
                    Created = DateTime.Parse("1/26/2018"),
                     StatusKey = 5
                }
                ,
                new AssessmentReview {
                    ClientId = 8,
                    ClientName ="Gavin McGinnis",
                    Assessment = "Spectra Form",
                    Updated = DateTime.Parse("1/26/2018"),
                    Created = DateTime.Parse("1/26/2018"),
                    StatusKey = 13
                }
            };
        }
        public IEnumerable<AssessmentReview> GetAll()
        {
            return  _assessmentReviews.OrderBy(x => x.Assessment);
        }

        public async Task<IEnumerable<AssessmentReview>> GetAllAsync(int? clientKey)
        {
            return await Task.Run(() => _assessmentReviews);
        }

        public async Task<AssessmentReview> AddAssessmentReview(AssessmentReview assessmentReview)
        {
            _assessmentReviews.Add(assessmentReview);
            return await Task.Run(() => assessmentReview);
        }
    }
}
