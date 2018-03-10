using System;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models
{
    public class Client
    {
        public string ClientId{ get; set; }
        public string ClientName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
        public bool IsUser { get; set; }
        public string ClinicianId { get; set; }
        public string Clinician { get; set; }
        public string GroupId { get; set; }
        public string GroupName { get; set; }
        
    }

}