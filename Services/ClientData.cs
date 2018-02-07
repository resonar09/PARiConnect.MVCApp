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
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientListingForUser = await coreServiceClient.GetClientListingForUserAsync(int.Parse(loggedInUserID));

            var clientListing = clientListingForUser.Clients
                .Select(x => new Client
                {
                    ClientId = x.ClientID,
                    ClientName = x.FirstName + " " + x.LastName,
                    Email = x.PrimaryEmail
                    //,
                    //Clinician = x.

                });
            return clientListing;
        }
    }
}

