using CoreServiceDevReference;
using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class ClientDataMock : IClientData
    {
        List<Models.Client> _clients;
        public ClientDataMock()
        {
            _clients = new List<Models.Client>();
            for(var i=0;i < 2000; i++){
                var client = new Models.Client();
                client.ClientId = i.ToString();
                client.ClientName = "Client" + i;
                client.Clinician = "Mike Nolan";
                client.IsUser = true;
                client.ClinicianId = "37";
                _clients.Add(client);
        }
            for(var i=2000;i < 4000; i++){
                var client = new Models.Client();
                client.ClientId = i.ToString();
                client.ClientName = "Client" + i;
                client.Clinician = "Roaming Crowder";
                client.IsUser = false;
                client.ClinicianId = "1";
                _clients.Add(client);
        }
        for(var i=4001;i < 4010; i++){
                var client = new Models.Client();
                client.ClientId = i.ToString();
                client.ClientName = "Client" + i;
                client.Clinician = "Roaming Crowder";
                client.IsUser = false;
                client.ClinicianId = "";
                client.GroupId = "55";
                _clients.Add(client);
        }
            
        }

        public Task<Models.Client> GetByKeyAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Client>> GetClientGroupListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Report>> GetClientReportsAsync(int clientKey, int clientAssessmentKey)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Client>> GetClientsByKeysAsync(int[] keys)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.Client>> GetListAsync()
        {

            return await Task.Run(() => _clients);
        }

        public  Task<CoreServiceDevReference.Client> SaveOrUpdate(CoreServiceDevReference.Client client,  CoreServiceDevReference.ClientGroup clientGroup)
        {
            throw new NotImplementedException();
        }

    }
}
