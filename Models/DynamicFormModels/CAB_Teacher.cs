using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class CAB_TEACHER : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }
        private IGroupData _groupData;
        
        public CAB_TEACHER(IGroupData groupData) 
        {
             _groupData = groupData;
            Settings = new Settings();
            Settings.Layout = LayoutType.TwoColumn;
            Settings.Columns = 2;
            Settings.Container = ContainerType.Modal;
            Settings.ContainerName = "cabTeacherModal";
            Settings.Columns = 2;
            Settings.Title = "CAB Teacher Form Demographics";
            Settings.FormSubmitText = "Submit";
            Settings.Labels = true;
            Settings.FormController = "Demographics";
            Settings.FormAction = "Index";
            Inputs = new List<Input>
            {
                new Input {
                    Id = InputIDType.testDate.ToString(),
                    Label = "Test Date:",
                    Type = InputType.date.ToString(),
                    Column = 1,
                    Placeholder ="",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The Test Date field is required!",
                    ValidationDateMessage = "A valid date must be entered"
                },
                new Input {
                    Id = InputIDType.firstName.ToString(),
                    Label = "Student's First Name:",
                    Type = InputType.text.ToString(),
                    Column = 1,
                    Placeholder ="Jerry",
                    Class = "",
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                },
                new Input {
                    Id = InputIDType.lastName.ToString(),
                    Label = "Student's Last Name:",
                    Type = InputType.text.ToString(),
                    Column = 1,
                    Placeholder ="Nolan",
                    Class = "",
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
                },
                new Input {
                    Id = InputIDType.clientId.ToString(),
                    Label = "ID Number:",
                    Type = InputType.text.ToString(),
                    Column = 1,
                    Placeholder ="123abc",
                    Class = "",
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },
                new Input {
                    Id = InputIDType.dateOfBirth.ToString(),
                    Label = "Student's Birthdate:",
                    Type = InputType.date.ToString(),
                    Column = 1,
                    Placeholder ="",
                    Class = "",
                },
                new Input {
                    Id = InputIDType.age.ToString(),
                    Label = "Student's Age:",
                    Type = InputType.text.ToString(),
                    Column = 1,
                    Placeholder ="",
                    Class = "",
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The Age field is required!"
                },
                new Input {
                    Id = InputIDType.gender.ToString(),
                    Label = "Student's Gender:",
                    Type = InputType.radio.ToString(),
                    Column = 1,
                    Options = Utility.GetGenderOptions(),
                    Placeholder ="",
                    Class = "",
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The gender field is required!"
                },
                new Input {
                    Id = InputIDType.grade.ToString(),
                    Label = "Grade:",
                    Type = InputType.select.ToString(),
                    Column = 2,
                    Options = Utility.GetGrade2Options(),
                    Placeholder ="",
                    Class = ""
                },
                new Input {
                    Id = InputIDType.raterName.ToString(),
                    Label = "Rater Name:",
                    Type = InputType.text.ToString(),
                    Column = 2,
                    Placeholder ="",
                    Class = "",
                },
                new Input {
                    Id = InputIDType.relationship.ToString(),
                    Label = "Position/Title:",
                    Type = InputType.select.ToString(),
                    Column = 2,
                    Options = Utility.GetTeacher2RelationshipOptions(),
                    Placeholder ="",
                    Class = ""
                },
                new Input {
                    Id = InputIDType.relationshipDesc.ToString(),
                    Label = "Position/Title Description:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.school.ToString(),
                    Label = "School/Agency:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.howLongKnown.ToString(),
                    Label = "How long known (Months):",
                    Type = InputType.text.ToString(),
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

