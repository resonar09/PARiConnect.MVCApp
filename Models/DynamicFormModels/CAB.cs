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
            Settings.ContainerName = "cabModal";
            Settings.Title = "CAB Demographics";
            Settings.FormSubmitText = "Submit";
            Settings.Labels = true;
            Settings.FormController = "Demographics";
            Settings.FormAction = "Index";
            Inputs = new List<Input>
            {
                new Input {
                    Id = "clientID",
                    Label = "Client Id:",
                    Type ="text",
                    Placeholder ="123abc",
                    Class = "col-6",
                    PrePendIcon = "address-card",
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },
                new Input {
                    Id = "dob",
                    Label = "Birthday:",
                    Type ="date",
                    Placeholder ="",
                    Class = "col-6",
                    PrePendIcon = "calendar",
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!",
                    ValidationDateMessage = "A valid date must be entered"
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
                    Id = "gender",
                    Label = "Gender:",
                    Type ="radio",
                    Options = new[] {new Option(1,"Male",false), new Option(2,"Female",false)},
                    Placeholder ="",
                    Class = "col-6",
                    Validation = true,
                    ValidationRequiredMessage = "The gender field is required!"
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
                        var option = new Option(group.ClientGroupKey,group.Name,false);
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

