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
    public class ClientData : IClientData
    {
        private IUserService _userService;

        public ClientData(IUserService userService)
        {
             _userService = userService;
        }

        public async Task<Models.Client> GetByKeyAsync(int id)
        {
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientRef = await coreServiceClient.GetClientByKeyAsync(id);
            var client = new Models.Client();
            client.ClientKey = clientRef.ClientKey;
            client.ClientId = clientRef.ClientID;
            client.ClientName = clientRef.FirstName + " " + clientRef.LastName;
            client.DateOfBirth = (clientRef.DateOfBirth.HasValue) ? clientRef.DateOfBirth.Value.ToShortDateString() : "---";
            client.Gender = (clientRef.Gender.HasValue) ? clientRef.Gender.Value.ToString() : "---";
            client.PrimaryEmail = clientRef.PrimaryEmail;
            client.GroupName = "---";
            client.Age = GetAgeFromDOBCalculated(clientRef.DateOfBirthComputed);
            return client;
        }
        private string GetAgeFromDOBCalculated(DateTime? dobCalculated){
            if(dobCalculated.HasValue){
                var today = DateTime.Today;
                var age = today.Year - dobCalculated.Value.Year;
                if (dobCalculated.Value > today.AddYears(-age)) age--;
                return age.ToString();
            }
            return "---";
        }
/*         public async Task<IEnumerable<Client>> GetListAsync()
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
        } */
        public async Task<IEnumerable<Models.Client>> GetListAsync()
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientListingForUser = await coreServiceClient.GetAllClientListingForUserAsync(int.Parse(loggedInUserID));
            var clinicians = await coreServiceClient.GetClinicianListingsForUserAsync(int.Parse(loggedInUserID));
            //var user = clinicians.Where(x=>x.OrgUserMappingKey == int.Parse(loggedInUserID)).Select(c => c.Name).SingleOrDefault();
            

             var clientListing = clientListingForUser.Clients
                .Select(x => new Models.Client
                {   ClientKey= x.ClientKey,
                    ClientId = x.ClientID,
                    ClientName = x.FirstName + " " + x.LastName,
                    Email = x.PrimaryEmail
                    ,Clinician = _userService.GetCurrentUserName()
                    ,ClinicianId = loggedInUserID
                    ,IsUser = true
                }).ToList(); 

                foreach(var clinicianClientGroup in clientListingForUser.ClientGroups){
                    foreach(var clinicianClientGroupClient in clinicianClientGroup.Clients){
                        var client = new Models.Client();
                        client.ClientKey = clinicianClientGroupClient.ClientKey;
                        client.Clinician =  _userService.GetCurrentUserName();
                        client.ClinicianId = loggedInUserID;
                        client.Email = clinicianClientGroupClient.PrimaryEmail;
                        client.ClientId = clinicianClientGroupClient.ClientID;
                        client.ClientName = string.Format("{0} {1}",clinicianClientGroupClient.FirstName, clinicianClientGroupClient.LastName);
                        client.GroupId = clinicianClientGroup.ClientGroupKey.ToString();
                        client.GroupName = clinicianClientGroup.Name;
                        client.IsUser = true;
                        clientListing.Add(client); 
                    }

                }            

            foreach(var clinician in clinicians){
                var clinicianClients = await coreServiceClient.GetAllClientListingForUserAsync(clinician.OrgUserMappingKey);
                foreach(var clinicianClient in clinicianClients.Clients){
                    var client = new Models.Client();
                    client.ClientKey = clinicianClient.ClientKey;
                    client.Clinician = clinician.Name;
                    client.ClinicianId = clinician.OrgUserMappingKey.ToString();
                    client.Email = clinicianClient.PrimaryEmail;
                    client.ClientId = clinicianClient.ClientID;
                    client.ClientName = string.Format("{0} {1}",clinicianClient.FirstName, clinicianClient.LastName);
                    clientListing.Add(client);
                }
                foreach(var clinicianClientGroup in clinicianClients.ClientGroups){
                    foreach(var clinicianClientGroupClient in clinicianClientGroup.Clients){
                        var client = new Models.Client();
                        client.ClientKey = clinicianClientGroupClient.ClientKey;
                        client.Clinician = clinician.Name;
                        client.ClinicianId = clinician.OrgUserMappingKey.ToString();
                        client.Email = clinicianClientGroupClient.PrimaryEmail;
                        client.ClientId = clinicianClientGroupClient.ClientID;
                        client.ClientName = string.Format("{0} {1}",clinicianClientGroupClient.FirstName, clinicianClientGroupClient.LastName);
                        client.GroupId = clinicianClientGroup.ClientGroupKey.ToString();
                        clientListing.Add(client); 
                    }

                }
            } 
            return clientListing;
        }
        public async Task<CoreServiceDevReference.Client> SaveOrUpdate(CoreServiceDevReference.Client client, CoreServiceDevReference.ClientGroup clientGroup)
        {
            var loggedInUserID = _userService.GetCurrentUserId();
            var loggedInUserName = _userService.GetCurrentUserName();
            CoreServiceDevReference.CoreServiceClient coreServiceClient = new CoreServiceDevReference.CoreServiceClient();
            var clientResult = await coreServiceClient.SaveOrUpdateClientAsync(client,int.Parse(loggedInUserID),clientGroup,loggedInUserName);
            return clientResult;
        }


    }
}

