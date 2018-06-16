using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IAssessmentReviewData
    {
       Task<IEnumerable<AssessmentReview>> GetAllAsync(int? clientKey);

       IEnumerable<AssessmentReview> GetAll();

       Task<AssessmentReview> AddAssessmentReview(AssessmentReview assessmentReview);
    }
}
