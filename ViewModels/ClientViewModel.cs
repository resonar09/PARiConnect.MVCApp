using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class ClientViewModel
    {
        public int ClinicianId { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}