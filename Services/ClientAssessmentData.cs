using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using CoreServiceDevReference;
using AutoMapper;

namespace PARiConnect.MVCApp.Services
{
    public class ClientAssessmentData : IClientAssessmentData
    {
        private IUserService _userService;

        public ClientAssessmentData(IUserService userService)
        {
             _userService = userService;
        }

        public async Task<ClientAssessment> SaveClientAssessmentDemographics(ClientAssessment clientAssessment)
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            var loggedInUserName = _userService.GetCurrentUserName();
            clientAssessment.OrgUserMappingKey = int.Parse(loggedInUserID);
            clientAssessment.TestDate = DateTime.Now;
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientAssessmentResult = await coreServiceClient.SaveClientAssessmentDemographicsAsync(int.Parse(loggedInUserID), clientAssessment, loggedInUserID);     //.SaveOrUpdateClientAsync(client, int.Parse(loggedInUserID), clientGroup, loggedInUserName);
            return clientAssessmentResult;
        }
    }
}

