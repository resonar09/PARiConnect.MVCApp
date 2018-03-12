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
            Settings.Layout = LayoutType.Custom;
            //Settings.DefaultClass = "";
            Settings.Container = ContainerType.Modal;
            Settings.Labels = false;
            Settings.FormController = "Clients";
            Settings.FormAction = "Create";
            Inputs = new List<Input>
            {
                new Input {
                    Id = "clientID",
                    Label = "Client Id",
                    Type ="text",
                    Placeholder ="123abc",
                    Class = "col-12",
                    Width = "200",
                    PrePendIcon = "address-card",
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },
                new Input {
                    Id = "firstName",
                    Label = "First Name",
                    Type ="text",
                    Placeholder ="Jerry",
                    Class = "col-6",
                    Width = "200",
                    Validation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                },
                new Input {
                    Id = "lastName",
                    Label = "Last Name",
                    Type ="text",
                    Placeholder ="Nolan",
                    Class = "col-6",
                    Width = "200",
                    Validation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
                }
            };
        }
    }
}