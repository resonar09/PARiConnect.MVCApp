using System;

namespace PARiConnect.MVCApp.Models
{
    public class Client
    {
        public string ClientId{ get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public bool IsUser { get; set; }
        public string ClinicianId { get; set; }
        public string Clinician { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }

    }

}