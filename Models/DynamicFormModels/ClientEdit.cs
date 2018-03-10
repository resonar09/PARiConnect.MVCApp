using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class ClientEdit
    {
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }
        public ClientEdit()
        { 
            Settings = new Settings();
            Settings.Layout = LayoutType.Stacked;
            Settings.Container = ContainerType.Modal;
            Settings.Labels = false;
            Inputs = new List<Input>
            {
                new Input {
                    Id = "clientID",
                    Label = "Client Id",
                    Type ="text",
                    Placeholder ="123abc",
                    Class = "",
                    Width = "200",
                    PrePendIcon = "lock",
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },
                new Input {
                    Id = "firstName",
                    Label = "First Name",
                    Type ="text",
                    Placeholder ="Jerry",
                    Class = "",
                    Width = "200",
                    Validation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                }
            };
        }
    }
}