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
    public class ClientData : IClientData
    {
        private IUserService _userService;
        public ClientData(IUserService userService)
        {
             _userService = userService;
        }

        public Task<IEnumerable<Client>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetListAsync()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            var loggedInUserName = _userService.GetCurrentUserName();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientListingForUser = await coreServiceClient.GetAllClientListingForUserAsync(int.Parse(loggedInUserID));

            var clientListing = clientListingForUser.Clients
                .Select(x => new Client
                {
                    ClientId = x.ClientID,
                    ClientName = x.FirstName + " " + x.LastName,
                    Email = x.PrimaryEmail
                    ,
                    Clinician = loggedInUserName
                });
            return clientListing;
        }
        public async Task<IEnumerable<Client>> GetListAsync(int id)
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientListingForUser = await coreServiceClient.GetAllClientListingForUserAsync(int.Parse(loggedInUserID));
            var clinicians = await coreServiceClient.GetClinicianListingsForUserAsync(int.Parse(loggedInUserID));
            var clinician = clinicians.Where(x=>x.OrgUserMappingKey == int.Parse(loggedInUserID)).Select(c => c.Name).SingleOrDefault();
            
            var clientListing = clientListingForUser.Clients
                .Select(x => new Client
                {
                    ClientId = x.ClientID,
                    ClientName = x.FirstName + " " + x.LastName,
                    Email = x.PrimaryEmail
                    ,
                    Clinician = clinician
                });
            return clientListing;
        }
    }
}

