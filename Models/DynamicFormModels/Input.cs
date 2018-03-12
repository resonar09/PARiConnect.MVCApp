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
        public int Min { get; set; } 
        public int Max { get; set; }        
        public string Value { get; set; }
        public string PrePendIcon { get; set; }
        public bool Validation { get; set; }
        public string ValidationRequiredMessage { get; set; }
        public string ValidationEmailMessage { get; set; }
        public string ValidationNumberMessage { get; set; }
        
        public Option[] Options { get; set; }
         public string ValidationDateMessage { get; set; }
    }
}