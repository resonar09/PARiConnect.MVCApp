using System;

namespace PARiConnect.MVCApp.Models
{
    public class RecentlyAccessed
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string Assessment { get; set; }
        public DateTime Updated { get; set; }

    }
}