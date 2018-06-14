using System.Collections.Generic;
using CoreServiceDevReference;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class EmailSettingsViewModel
    {
        public IEnumerable<EmailTemplate> EmailTemplates { get; set; }
    }
}