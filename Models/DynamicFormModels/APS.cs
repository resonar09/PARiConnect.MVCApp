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
            Settings.Layout = LayoutType.TwoColumn;
            Settings.Container = ContainerType.Modal;
            Settings.Columns = 2;
            Settings.DefaultClass = "small";
            Settings.ContainerName = "apsModal";
            Settings.Title = "APS Demographics";
            Settings.FormSubmitText = "Submit";
            Settings.Labels = true;
            Settings.FormController = "";
            Settings.FormAction = "";
            Settings.ShowValidation = false;


            // Settings.Layout = LayoutType.Stacked;
            //Settings.Container = ContainerType.Page;
            Inputs = new List<Input>
            {
                 new Input {
                    Id = InputIDType.primaryEmail.ToString(),
                    Label = "Email",
                    Column = 1,
                    Type = InputType.email.ToString(),
                    Class = "form-control-sm",
                    BatchValidation = true,
                    ValidationRequiredMessage = "Email is required!"
                },
                new Input {
                    Id = InputIDType.raterName.ToString(),
                    Label = "Examiner",
                    Column = 1,
                    Type = InputType.text.ToString(),
                    Class = "form-control-sm",
                    BatchValidation = false,
                },
                new Input {
                    Id = InputIDType.clientId.ToString(),
                    Label = "Client Id",
                    Type = InputType.text.ToString(),
                    Column = 1,
                    Class = "form-control-sm",
                    BatchValidation = true,
                    ValidationRequiredMessage = "Client ID is required!"
                },
                new Input {
                    Id = InputIDType.firstName.ToString(),
                    Label = "First Name",
                    Column = 1,
                    Type = InputType.text.ToString(),
                    Class = "form-control-sm",
                    BatchValidation = true,
                    ValidationRequiredMessage = "First Name is required!"
                },
                 new Input {
                    Id = InputIDType.lastName.ToString(),
                    Label = "Last Name",
                    Type = InputType.text.ToString(),
                    Column = 1,
                    Class = "form-control-sm",
                    BatchValidation = true,
                    ValidationRequiredMessage = "Last Name is required!"
                },
                new Input {
                    Id = InputIDType.testDate.ToString(),
                    Label = "Test Date",
                    Type = InputType.date.ToString(),
                    Column = 1,
                    Class = "form-control-sm hide-item",
                },
                new Input {
                    Id = InputIDType.gender.ToString(),
                    Label = "Gender",
                    Type = InputType.radio.ToString(),
                    Column = 1,
                    Options = Utility.GetGenderOptions(),
                    Class = "form-control-sm",
                    BatchValidation = true,
                    ValidationRequiredMessage = "Gender is required!"
                },
                new Input {
                    Id = InputIDType.grade.ToString(),
                    Label = "Grade in School",
                    Type = InputType.select.ToString(),
                    Column = 1,
                    Options = Utility.GetAPSGradeOptions(),
                    Class = "form-control-sm",
                    BatchValidation = false,
                },
                new Input {
                    Id = InputIDType.dateOfBirth.ToString(),
                    Label = "Birth Date",
                    Type = InputType.date.ToString(),
                    Column = 1,
                    Class = "form-control-sm",
                    BatchValidation = true,
                    ValidationRequiredMessage = "Birthdate is required!"
                },
                new Input {
                    Id = InputIDType.heightFeet.ToString(),
                    Label = "Height(feet)",
                    Column = 2,
                    Type = InputType.text.ToString(),
                    Class = "form-control-sm",
                    BatchValidation = false
                },
                new Input {
                    Id = InputIDType.heightInches.ToString(),
                    Label = "Height(inches)",
                    Column = 2,
                    Type = InputType.text.ToString(),
                    Class = "form-control-sm",
                    BatchValidation = false
                },
                new Input {
                    Id = InputIDType.weight.ToString(),
                    Label = "Weight",
                    Column = 2,
                    Type = InputType.text.ToString(),
                    Class = "form-control-sm",
                    BatchValidation = false
                },
                new Input {
                    Id = InputIDType.age.ToString(),
                    Label = "Age",
                    Column = 2,
                    Type = InputType.text.ToString(),
                    Class = "form-control-sm",
                    BatchValidation = false
                },
                new Input {
                    Id = InputIDType.ethnicity.ToString(),
                    Label = "Ethnicity",
                    Type = InputType.select.ToString(),
                    Column = 2,
                    Options = Utility.GetEthnicityOptions(),
                    Class = "form-control-sm",
                    BatchValidation = false
                },
                new Input {
                    Id = InputIDType.school.ToString(),
                    Label = "School/Agency",
                    Type = InputType.text.ToString(),
                    Column = 2,
                    Class = "form-control-sm",
                    BatchValidation = false
                },
                new Input {
                    Id = InputIDType.schoolStatus.ToString(),
                    Label = "School Status",
                    Type = InputType.select.ToString(),
                    Column = 2,
                    Options = Utility.GetSchoolStatusOptions(),
                    Class = "form-control-sm",
                    BatchValidation = false
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