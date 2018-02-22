using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models
{
    public class CAD
    {
        public List<Input> _inputs;
        public CAD()
        {
        Input email = new Input();
        email.Label = "Email";
        email.Type = "email";
        Input password = new Input();
        password.Label = "Password";
        password.Type = "password";
        
         _inputs = new List<Input>();
         _inputs.Add(email);
         _inputs.Add(password);

        }
    }
}