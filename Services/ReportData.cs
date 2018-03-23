using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace PARiConnect.MVCApp.Services
{
    public class ReportData : IReportData
    {
        private IUserService _userService;
        public ReportData(IUserService userService)
        {
            _userService = userService;
        }

        public Task<IEnumerable<Report>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Report>> GetListAsync()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            // TODO: access clients?
            var reportListingForUser = await coreServiceClient.GetReportsBySearchCriteriaAsync(null, null, null, null, null, false, false, null, null, int.Parse(loggedInUserID), null);
            var clientListingForUser = await coreServiceClient.GetAllClientListingForUserAsync(int.Parse(loggedInUserID));
            //var clinicians = await coreServiceClient.GetClinicianListingsForUserAsync(int.Parse(loggedInUserID));
            //var user = clinicians.Where(x=>x.OrgUserMappingKey == int.Parse(loggedInUserID)).Select(c => c.Name).SingleOrDefault();

            var reportListing = reportListingForUser
                .Select(x => new Report
                {
                    ClientId = x.ClientID,
                    ClientName = x.ClientName,
                    ReportName = x.ProductName,
                    AssignedDate = x.DateAssigned,
                    CompletedDate = x.DateCompleted,
                    ReportKey = x.ReportKey
                }).ToList();

            return reportListing;

        }
    }
}

