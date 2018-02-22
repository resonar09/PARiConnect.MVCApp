using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models
{
    public class Input
    {
        public string Id { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Placeholder { get; set; }
        public string Class { get; set; }
        public string Width { get; set; }
        public string Value { get; set; }
        public bool Validation { get; set; }
        public string ValidationRequiredMessage { get; set; }
        public string ValidationEmailMessage { get; set; }
    }
}