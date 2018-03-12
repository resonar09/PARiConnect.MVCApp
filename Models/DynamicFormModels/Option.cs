using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class Option
    {
        public Option(int key, string value, bool selected)
        {
            Key = key;
            Value = value;
            Selected = selected;
        }
        public int Key { get; set; }
        public string Value { get; set; }
        public bool Selected { get; set; }
    }
}