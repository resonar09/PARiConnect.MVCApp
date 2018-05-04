namespace PARiConnect.MVCApp.Models
{
    public class AssessmentForm
    {
        public AssessmentForm()
        {       
        }

        public AssessmentForm(string name)
        {
            Name = name;
        }
        public int AssessmentFormKey { get; set; }
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }

    }
}