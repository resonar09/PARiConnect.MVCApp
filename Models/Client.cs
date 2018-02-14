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
<<<<<<< HEAD
        public string GroupId { get; set; }
=======
        public int ClinicianId { get; set; }
>>>>>>> 6a67cdf5b1887fd2947b170eed446828d0e2ff98
    }
}