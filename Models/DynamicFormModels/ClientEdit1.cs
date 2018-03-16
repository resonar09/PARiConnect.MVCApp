using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using PARiConnect.MVCApp.Services;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class ClientEdit1
    {
        //private IGroupData _groupData;
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }
        public ClientEdit1()
        {
  
            Settings = new Settings();
            Settings.Layout = LayoutType.Custom;
            //Settings.DefaultClass = "";
            Settings.Container = ContainerType.Modal;
            Settings.Labels = true;
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
                    Validation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                },
                new Input {
                    Id = "lastName",
                    Label = "Last Name",
                    Type ="text",
                    Placeholder ="Nolan",
                    Class = "col-6",
                    Validation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
                },
                new Input {
                    Id = "birthday",
                    Label = "Birthday",
                    Type ="date",
                    Placeholder ="",
                    Class = "col-6",
                    Validation = false,
                    ValidationDateMessage = "A valid date is required!"
                },
                new Input {
                    Id = "age",
                    Label = "Age",
                    Type ="number",
                    Min = 0,
                    Max = 120,
                    Placeholder ="",
                    Class = "col-6",
                    Validation = true,
                    ValidationNumberMessage = "A valid age is required!"
                },
                new Input {
                    Id = "gender",
                    Label = "Gender",
                    Type ="select",
                    Options = new[] {new Option(1,"Male",true), new Option(2,"Female",false)},
                    Placeholder ="",
                    Class = "col-6"
                },
                new Input {
                    Id = "group",
                    Label = "Group",
                    Type ="select",
                    Options = new[] {new Option(1,"Male",true), new Option(2,"Female",false)},
                    Placeholder ="",
                    Class = "col-6"
                },
                new Input {
                    Id = "primaryEmail",
                    Label = "Primary Email",
                    Type ="email",
                    Placeholder ="",
                    Class = "col-6",
                    Validation = false,
                    ValidationEmailMessage = "A valid email is required!"
                },
                new Input {
                    Id = "secondaryEmail",
                    Label = "Secondary Email",
                    Type ="email",
                    Placeholder ="",
                    Class = "col-6",
                    Validation = false,
                    ValidationEmailMessage = "A valid email is required!"
                }
            };
        }

/*         public Option[] GetOptions()
        {
            List<Option> optionList = new List<Option>();  
            var groupList =  _groupData.GetListAsync().Result;
            foreach(var group in groupList){
                optionList.Add(new Option(group.GroupId,group.GroupName,false));
            }
            return optionList.ToArray();
        } */

    }
}