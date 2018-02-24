using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class Login
    {

        public Settings Settings { get; set; }
        public List<Input> Inputs { get; set; }

        public Login()
        {
            Settings = new Settings();
            Settings.Layout = "Stacked";

            Inputs = new List<Input>
            {
                new Input {
                    Id = "email",
                    Label = "Email",
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
                    Width = "300",
                    Validation = true,
                    ValidationRequiredMessage = "The Password field is required!"
                },
            };
        }


    }
}