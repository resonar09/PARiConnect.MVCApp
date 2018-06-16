using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class CAD_2077 : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }

        public Settings Settings { get; set; }
        private IGroupData _groupData;

        public CAD_2077(IGroupData groupData)
        {
            _groupData = groupData;
            Settings = new Settings();
            Settings.Layout = LayoutType.TwoColumn;
            Settings.Container = ContainerType.Page;
            Settings.Columns = 2;
            Settings.ContainerName = "cadModal";
            Settings.Title = "CAD Demographics";
            Settings.FormSubmitText = "Submit";
            Settings.Labels = true;
            Settings.FormController = "";
            Settings.FormAction = "";
            Settings.ShowValidation = false;
            Settings.Display = DisplayType.Table;

            // Settings.Layout = LayoutType.Stacked;
            //Settings.Container = ContainerType.Page;
            Inputs = new List<Input>
            {    new Input {
                    Id = InputIDType.primaryEmail.ToString(),
                    Label = "Email",
                    Column = 1,
                    Type = InputType.email.ToString(),
                    Class = "form-control-sm",
                    ClientData = true,
                    ClientDataValidation = true,
                    ValidationRequiredMessage = "Email is required!"
                },
                new Input {
                    Id = InputIDType.firstName.ToString(),
                    Label = "First Name:",
                    Column = 1,
                    Type = InputType.text.ToString(),
                    Class = "form-control-sm",
                    ClientData = true,
                    ClientDataOrdinal = 1,
                    ClientDataValidation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                },
                new Input {
                    Id = InputIDType.lastName.ToString(),
                    Label = "Last Name:",
                    Type = InputType.text.ToString(),
                    Column = 1,
                    Class = "form-control-sm ",
                    ClientData = true,
                    ClientDataOrdinal = 2,
                    ClientDataValidation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
                },
                new Input {
                    Id = InputIDType.clientId.ToString(),
                    Label = "Client Id:",
                    Type = InputType.text.ToString(),
                    Column = 1,
                    Placeholder ="123abc",
                    Class = "form-control-sm",
                    ClientData = true,
                    ClientDataOrdinal = 3,
                    ClientDataValidation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },
                new Input {
                    Id = InputIDType.gender.ToString(),
                    Label = "Gender:",
                    Type = InputType.radio.ToString(),
                    Column = 1,
                    ClientData = true,
                    ClientDataOrdinal = 5,
                    ClientDataValidation = true,
                    Options = new[] {new Option(1,"Female",false), new Option(2, "Male", false)},
                    Class = "form-control-sm"
                },
                new Input {
                    Id = InputIDType.age.ToString(),
                    Label = "Age:",
                    Column = 2,
                    Type = InputType.number.ToString(),
                    Min = 0,
                    Max = 130,
                    Class = "form-control-sm",
                    ClientData = true,
                    TestDataOrdinal = 2,
                    ClientDataValidation = true,
                    ValidationRequiredMessage = "The Age field is required!"
                },

                new Input {
                    Id = InputIDType.dateOfBirth.ToString(),
                    Label = "Birthdate:",
                    Type = InputType.date.ToString(),
                    Column = 2,
                    ClientData = true,
                    ClientDataOrdinal = 4,
                    Class = "form-control-sm"
                },

                new Input {
                    Id = InputIDType.testDate.ToString(),
                    Label = "Test Date:",
                    Type = InputType.date.ToString(),
                    Column = 2,
                    Class = "form-control-sm hide-item",
                    ClientData = false,
                    TestDataOrdinal = 1,
                    ValidationRequiredMessage = "The Test Date field is required!",
                    ValidationDateMessage = "A valid date must be entered"
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