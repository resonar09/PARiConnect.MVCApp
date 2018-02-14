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
            _clients = new List<Client>
            {
                new Client {
                    ClientId = "1",
                    ClientName ="Sam Smith",
                    Email = "samsmith@gmail.com",
                    Clinician = "Lane Meyers"

                }, 
                new Client {
                    ClientId = "2",
                    ClientName ="Liz Evins",
                    Email = "lizevans@gmail.com",
                    Clinician = "Lane Meyers"
                },
                new Client {
                    ClientId = "3",
                    ClientName ="Mike Smith",
                    Email = "mikesmith@gmail.com",
                    Clinician = "Richard Spencer"
                },
                new Client {
                    ClientId = "4",
                    ClientName ="Tab Johnson"

                },
                new Client {
                    ClientId = "5",
                    ClientName ="Chris Peterson"
                },
                new Client {
                    ClientId = "6",
                    ClientName ="Steve Crowder"
                },
                new Client {
                    ClientId = "7",
                    ClientName ="Dave Rubin"
                },
                new Client {
                    ClientId = "8",
                    ClientName ="Gavin McGinnis"
                },
                new Client {
                    ClientId = "6",
                    ClientName ="Steve Crowder"
                },
                new Client {
                    ClientId = "7",
                    ClientName ="Dave Rubin"
                },
                new Client {
                    ClientId = "8",
                    ClientName ="Gavin McGinnis"
                }
            };
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
