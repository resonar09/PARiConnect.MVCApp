using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class CAD
    {
        public List<Input> Inputs { get; set; }

        public Settings Settings { get; set; }
        public CAD()
        {   
            Settings = new Settings();
            Settings.Layout = LayoutType.Stacked;
            Settings.Container = ContainerType.Page;
            Inputs = new List<Input>
            {
                new Input {
                    Id = "test",
                    Label = "Username",
                    Type ="email",
                    Placeholder ="sample3@email.com",
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