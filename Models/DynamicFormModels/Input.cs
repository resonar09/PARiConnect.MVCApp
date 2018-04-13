using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class Input
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Placeholder { get; set; }
        public string Class { get; set; }
        public int Column { get; set; }
        public int Min { get; set; } 
        public int Max { get; set; }        
        public string Value { get; set; }
        public string PrePendIcon { get; set; }
        public string Pattern { get; set; }
        public bool Validation { get; set; }
        public string ValidationRequiredMessage { get; set; }
        public string ValidationEmailMessage { get; set; }
        public string ValidationNumberMessage { get; set; }
        
        public IEnumerable<Option> Options { get; set; }

        public IEnumerable<Input> List { get; set; }
        public string ValidationDateMessage { get; set; }
        public string OnChange { get; set; }
    }
}