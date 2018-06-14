using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class SIMS : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }
        private IGroupData _groupData;

        public SIMS(IGroupData groupData)
        {
            _groupData = groupData;
            Settings = new Settings();
            Settings.Layout = LayoutType.TwoColumn;
            Settings.Container = ContainerType.Modal;
            Settings.ContainerName = "simsModal";
            Settings.Columns = 2;
            Settings.Title = "SIMS Demographics";
            Settings.FormSubmitText = "Submit";
            Settings.Labels = true;
            Settings.FormController = "Demographics";
            Settings.FormAction = "Index";
            Inputs = new List<Input>
            {
                new Input {
                    Id = InputIDType.firstName.ToString(),
                    Label = "First Name:",
                    Type = InputType.text.ToString(),
                    Placeholder ="Jerry",
                    Class = "",
                    Column = 1,
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                },
                new Input {
                    Id = InputIDType.lastName.ToString(),
                    Label = "Last Name:",
                    Type = InputType.text.ToString(),
                    Placeholder ="Nolan",
                    Class = "",
                    Column = 1,
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
                },
                new Input {
                    Id = InputIDType.clientId.ToString(),
                    Label = "ID Number:",
                    Type = InputType.text.ToString(),
                    Placeholder ="123abc",
                    Class = "",
                    Column = 1,
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },

                new Input {
                    Id = InputIDType.dateOfBirth.ToString(),
                    Label = "Birthdate:",
                    Type = InputType.date.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 1,
                },
                new Input {
                    Id = InputIDType.gender.ToString(),
                    Label = "Gender:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetGenderOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 1,
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The Gender field is required!"
                },
                new Input {
                    Id = InputIDType.testDate.ToString(),
                    Label = "Test Date:",
                    Type = InputType.date.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 1,
                    Validation = true,
                    ValidationRequiredMessage = "The Test Date field is required!",
                    ValidationDateMessage = "A valid date must be entered"
                },
                new Input {
                    Id = InputIDType.age.ToString(),
                    Label = "Age:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 1,
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The Age field is required!"
                },
                new Input {
                    Id = InputIDType.maritalStatus.ToString(),
                    Label = "Marital Status:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetMaritalStatusOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 1,
                },
                new Input {
                    Id = InputIDType.occupation.ToString(),
                    Label = "Occupation:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.educationYears.ToString(),
                    Label = "Education (Years):",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.ethnicity.ToString(),
                    Label = "Ethnicity:",
                    Type = InputType.checkbox.ToString(),
                    Options = Utility.GetEthnicity4Options(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.testLocation.ToString(),
                    Label = "Test Location:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.setting.ToString(),
                    Label = "Context/Setting:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetSettingOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.purpose.ToString(),
                    Label = "Purpose of Test:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetPurposeOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.symptoms.ToString(),
                    Label = "Reported Symptoms:",
                    Type = InputType.checkbox.ToString(),
                    Options = Utility.GetSymptomsOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
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

