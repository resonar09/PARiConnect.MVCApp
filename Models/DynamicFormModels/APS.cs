using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class APS : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }

        public Settings Settings { get; set; }
        private IGroupData _groupData;

        public APS(IGroupData groupData)
        {
            _groupData = groupData;
            Settings = new Settings();
            Settings.Layout = LayoutType.Custom;
            Settings.Container = ContainerType.Page;
            Settings.Columns = 2;
            Settings.ContainerName = "cadModal";
            Settings.Title = "CAD Demographics";
            Settings.FormSubmitText = "Submit";
            Settings.Labels = true;
            Settings.FormController = "Assess";
            Settings.FormAction = "Index";


           // Settings.Layout = LayoutType.Stacked;
            //Settings.Container = ContainerType.Page;
            Inputs = new List<Input>
            {
                new Input {
                    Id = "firstName",
                    Label = "First Name:",
                    Column = 1,
                    Type ="text",
                    Placeholder ="Jerry",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                },
                new Input {
                    Id = "age",
                    Label = "Age:",
                    Column = 2,
                    Type ="text",
                    Placeholder ="",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The Age field is required!"
                },
                new Input {
                    Id = "lastName",
                    Label = "Last Name:",
                    Type ="text",
                    Column = 1,
                    Placeholder ="Nolan",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
                },
                new Input {
                    Id = "dob",
                    Label = "Birthdate:",
                    Type ="date",
                    Column = 2,
                    Placeholder ="",
                    Class = "",
                },
                new Input {
                    Id = "clientID",
                    Label = "Client Id:",
                    Type ="text",
                    Column = 1,
                    Placeholder ="123abc",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },
                new Input {
                    Id = "testDate",
                    Label = "Test Date:",
                    Type ="date",
                    Column = 2,
                    Placeholder ="",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The Test Date field is required!",
                    ValidationDateMessage = "A valid date must be entered"
                },
                new Input {
                    Id = "gender",
                    Label = "Gender:",
                    Type ="radio",
                    Column = 1,
                    Options = new[] {new Option(1,"Female",false), new Option(2, "Male", false)},
                    Placeholder ="",
                    Class = "",
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
            if (_groupData != null)
            {
                foreach (var group in _groupData.GetListAsync().Result)
                {
                    var option = new Option(group.ClientGroupKey, group.Name, false);
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