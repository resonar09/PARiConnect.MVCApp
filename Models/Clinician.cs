using System;
using System.Collections.Generic;

namespace PARiConnect.MVCApp.Models
{
    public class Clinician
    {
        public int OrgUserMappingKey{ get; set; }
        public string Name { get; set; }

        public IEnumerable<Client> Clients { get; set; }

        //public IEnumerable<Group> Groups { get; set; }
    }
}