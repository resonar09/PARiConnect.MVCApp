namespace PARiConnect.MVCApp.Models
{
    public class User
    {
        public User(string email)
        {
            this.Email = email;
            //this.Password = password;

        }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}