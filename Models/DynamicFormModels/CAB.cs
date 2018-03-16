using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class CAB : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }
        private IGroupData _groupData;

        public CAB(IGroupData groupData)
        {
             _groupData = groupData;
            Settings = new Settings();
            Settings.Layout = LayoutType.Custom;
            Settings.Container = ContainerType.Modal;
            Settings.Labels = true;
            Settings.FormController = "Clients";
            Settings.FormAction = "Create";
            Inputs = new List<Input>
            {
                new Input {
                    Id = "clientID",
                    Label = "Client Id:",
                    Type ="text",
                    Placeholder ="123abc",
                    Class = "col-12",
                    PrePendIcon = "address-card",
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },
                new Input {
                    Id = "firstName",
                    Label = "First Name:",
                    Type ="text",
                    Placeholder ="Jerry",
                    Class = "col-6",
                    Validation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                },
                new Input {
                    Id = "lastName",
                    Label = "Last Name:",
                    Type ="text",
                    Placeholder ="Nolan",
                    Class = "col-6",
                    Validation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
                },
                new Input {
                    Id = "birthday",
                    Label = "Birthday:",
                    Type ="date",
                    Placeholder ="",
                    Class = "col-6",
                    Validation = false,
                    ValidationDateMessage = "A valid date is required!"
                },
                new Input {
                    Id = "age",
                    Label = "Age:",
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
                    Label = "Gender:",
                    Type ="select",
                    Options = new[] {new Option(1,"Male",true), new Option(2,"Female",false)},
                    Placeholder ="",
                    Class = "col-6"
                },
                new Input {
                    Id = "group",
                    Label = "Group:",
                    Type ="select",
                    Options = new[] {new Option(1,"Male",true), new Option(2,"Female",false)},
                    Placeholder ="",
                    Class = "col-6"
                },
                new Input {
                    Id = "primaryEmail",
                    Label = "Primary Email:",
                    Type ="email",
                    Placeholder ="",
                    Class = "col-6",
                    Validation = false,
                    ValidationEmailMessage = "A valid email is required!"
                },
                new Input {
                    Id = "secondaryEmail",
                    Label = "Secondary Email:",
                    Type ="email",
                    Placeholder ="",
                    Class = "col-6",
                    Validation = false,
                    ValidationEmailMessage = "A valid email is required!"
                }
            };
        }

        public string GetName()
        {
                return this.GetType().Name;
        }
        public IEnumerable<Option> GetGroups()
        {       
            var optionList = new List<Option>();
            if(_groupData != null){
                    foreach(var group in _groupData.GetListAsync().Result){
                        var option = new Option(group.GroupId,group.GroupName,false);
                        optionList.Add(option);
                    }
            }
            return optionList;
        }

        public async Task<IEnumerable<Input>> GetInputsAsync()
        {
            return await Task.Run(() => Inputs);
        }

        public async Task<Settings> GetSettingsAsync()
        {
            return await Task.Run(() => Settings);
        }
    }
}

