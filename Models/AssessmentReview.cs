namespace PARiConnect.MVCApp.Models
{
    public class AssessmentReview
    {
        private int _statusKey;
        private string _status;
        private bool _completed;

        public string ClientName { get; set; }
        public string Assessment { get; set; }
        public string Updated { get; set; }

        public string Status
        {
            get
            {
                return _status;
            }
        }
        public int StatusKey
        {
            get
            {
                return _statusKey;
            }
            set
            {
                _statusKey = value;
                _status = ClientAssessmentStatus.GetStatus(value);
                _completed = ClientAssessmentStatus.GetCompleted(value);
            }
        }

        public bool Completed
        {
            get
            {
                return _completed;
            }

        }
    }
}