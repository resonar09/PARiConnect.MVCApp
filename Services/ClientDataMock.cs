using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public class ClientDataMock : IClientData
    {
        List<Client> _clients;
        public ClientDataMock()
        {
            _clients = new List<Client>();
            for(var i=0;i < 4000; i++){
                var client = new Client();
                client.ClientId = i.ToString();
                client.ClientName = "Client" + i;
                client.Clinician = "Mike Nolan";
                client.IsUser = true;
                client.ClinicianId = "37";
                _clients.Add(client);
        }
            for(var i=4000;i < 8000; i++){
                var client = new Client();
                client.ClientId = i.ToString();
                client.ClientName = "Client" + i;
                client.Clinician = "Roaming Crowder";
                client.IsUser = true;
                client.ClinicianId = "1";
                _clients.Add(client);
        }
            
        }

        public async Task<IEnumerable<Client>> GetListAsync()
        {
            return await Task.Run(() => _clients);
        }

        Task<IEnumerable<Client>> IClientData.GetAll()
        {
            return  Task.Run(() => _clients.Select(x=>x));
        }
    }
}
