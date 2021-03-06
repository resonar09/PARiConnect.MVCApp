﻿using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

namespace PARiConnect.MVCApp.Services
{
    public class ClinicianData : IClinicianData
    {
        private IUserService _userService;
        public ClinicianData(IUserService userService)
        {
             _userService = userService;
        }

        public Task<IEnumerable<Clinician>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Clinician>> GetListAsync()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clinicianListingForUser = await coreServiceClient.GetClinicianListingsForUserAsync(int.Parse(loggedInUserID));

            var clinicianListing = clinicianListingForUser
                .Select(x => new Clinician
                {
                    OrgUserMappingKey = x.OrgUserMappingKey,
                    Name = x.Name,
                    Clients = x.ClientListing.Clients.Select(c => new Client {
                        ClientId = c.ClientID,
                        ClientName = string.Format("{0} {1}", c.FirstName, c.LastName),
                        Email = c.PrimaryEmail,
                        Clinician = x.Name
                    })

                });
            return clinicianListing;
        }
        public async Task<OrgUserServiceDevReference.OrgUserInvitation> InviteAsync(string firstName, string lastName, string email, int permissionProfileKey, 
                                                              OrgUserServiceDevReference.OrgUserMappingPerm[] permissions, int orgUserMappingKey)
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            OrgUserServiceDevReference.OrgUserServiceClient orgUserServiceClient = new OrgUserServiceDevReference.OrgUserServiceClient();
            var orgUserInvitation = await orgUserServiceClient.CreateNewOrgUserInvitationAsync(firstName,lastName,email,permissionProfileKey, permissions,orgUserMappingKey,loggedInUserID);

            return orgUserInvitation;
        }
    }
}

