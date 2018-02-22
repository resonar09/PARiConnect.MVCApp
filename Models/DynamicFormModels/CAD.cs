using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models
{
    public class CAD
    {
        public List<Input> _inputs;
        public CAD()
        {
            _inputs = new List<Input>
            {
                new Input {
                    Id = "username",
                    Label = "Username",
                    Type ="email",
                    Placeholder ="sample@email.com",
                    Class = "",
                    Width = "200",
                    Validation = true,
                    ValidationEmailMessage = "The Email Address field is not a valid email address.",
                    ValidationRequiredMessage = "The Email Address field is required!"
                },
                new Input {
                    Id = "password",
                    Label = "Password",
                    Type ="password",
                    Class = "",
                    Width = "300"
                },
            };
        }
    }
}