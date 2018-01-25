namespace PARiConnect.MVCApp.Models
{
    public class User
    {
        public User(string email)
        {
            this.Email = email;
        }
        public User(string email, string fullname, string contactid, string orgusermappingkey)
        {
            this.Email = email;
            this.FullName = fullname;
            this.ContactId = contactid;
            this.OrgUserMappingKey = orgusermappingkey;
            
        }
        public string Email { get; set; }
        public string FullName { get; set; }
        
        public string ContactId { get; set; }
        public string OrgUserMappingKey { get; set; }
        public string Password { get; set; }
    }
}