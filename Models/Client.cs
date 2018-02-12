using System;

namespace PARiConnect.MVCApp.Models
{
    public class Client
    {
        public string ClientId{ get; set; }
        public string ClientName { get; set; }
        public string Email { get; set; }
        public string Clinician { get; set; }
        public int ClinicianId { get; set; }
    }
}