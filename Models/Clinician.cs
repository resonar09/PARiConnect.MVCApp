using System;
using System.Collections.Generic;

namespace PARiConnect.MVCApp.Models
{
    public class Clinician
    {
        public int OrgUserMappingKey{ get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        public int OrgUserInvitationKey{ get; set; }
        public int PermissionProfileId{ get; set; }
        public int ALLOCATE_INVENTORY{ get; set; }
        public int ASSIGN_ASSESSMENTS{ get; set; }
        public int ACCESS_NEEDS_REVIEW{ get; set; }
        public int ACCESS_REPORTS{ get; set; }
        public int ACCESS_CLIENTS{ get; set; } 
        public IEnumerable<Client> Clients { get; set; }
    }
}