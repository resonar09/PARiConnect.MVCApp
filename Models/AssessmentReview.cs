using System;

namespace PARiConnect.MVCApp.Models
{
    public class AssessmentReview
    {
        private int _statusKey;
        private string _status;
        private bool _completed;
        private bool _scored;

        public int ClientId{ get; set; }
        public string ClientName { get; set; }
        public string Assessment { get; set; }
        public DateTime Updated { get; set; }

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
                _scored = ClientAssessmentStatus.GetScored(value);

            }
        }
        public bool Completed
        {
            get
            {
                return _completed;
            }

        }
        public bool Scored
        {
            get
            {
                return _scored;
            }
        }
    }
}