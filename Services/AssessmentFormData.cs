using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
//using CoreServiceDevReference;

namespace PARiConnect.MVCApp.Services
{
    public class AssessmentFormData : IAssessmentFormData
    {

        public AssessmentFormData()
        {
          
        }
        public async Task<CoreServiceDevReference.AssessmentForm> GetByKeyAsync(int key)
        {
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var assessmentFormRef = await coreServiceClient.GetAssessmentFormByKeyAsync(key);

            return assessmentFormRef;
        }
    }
}

