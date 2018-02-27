using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class ClientEditViewModel
    {
        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string PrimaryEmail { get; set; }
        public string SecondaryEmail { get; set; }
       
    }
}