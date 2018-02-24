using System.Collections.Generic;
using PARiConnect.MVCApp.Models.DynamicFormModels;

namespace PARiConnect.MVCApp.ViewModels
{
    public class DynamicFormViewModel
    {
        public string Layout { get; set; }
        
        public IEnumerable<Input> Inputs { get; set; }
        
    }
}