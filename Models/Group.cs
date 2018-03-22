using System;
using System.Collections.Generic;

namespace PARiConnect.MVCApp.Models
{
    public class Group
    {
        public int ClientGroupKey{ get; set; }
        public string Name { get; set; }
        public int ClientCount{ get; set; }
        public string GroupId { get; set; }
        public int OrgUserMappingKey { get; set; }
        public IEnumerable<Client> Clients { get; set; }

    }
}