using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please enter an email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
    }
}