using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class BRIEF2_TEACHER : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }
        private IGroupData _groupData;
        
        public BRIEF2_TEACHER(IGroupData groupData) 
        {
             _groupData = groupData;
            Settings = new Settings();
            Settings.Layout = LayoutType.TwoColumn;
            Settings.Container = ContainerType.Modal;
            Settings.ContainerName = "brief2TeacherModal";
            Settings.Columns = 2;
            Settings.Title = "BRIEF2 Teacher Form Demographics";
            Settings.FormSubmitText = "Submit";
            Settings.Labels = true;
            Settings.FormController = "Demographics";
            Settings.FormAction = "Index";
            Inputs = new List<Input>
            {
                new Input {
                    Id = InputIDType.firstName.ToString(),
                    Label = "Student's First Name:",
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
                    Label = "Student's Last Name:",
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
                    Label = "Id Number:",
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
                    Id = InputIDType.gender.ToString(),
                    Label = "Gender:",
                    Type = InputType.radio.ToString(),
                    Options = Utility.GetGenderOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 1,
                    BatchValidation = true,
                    Validation = true,
                    ValidationRequiredMessage = "The gender field is required!"
                },
                new Input {
                    Id = InputIDType.grade.ToString(),
                    Label = "Grade:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetGradeOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 2
                },
                new Input {
                    Id = InputIDType.raterName.ToString(),
                    Label = "Rater Name:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.relationship.ToString(),
                    Label = "Relationship To Student:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetTeacherRelationshipOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 2
                },
                new Input {
                    Id = InputIDType.classTaught.ToString(),
                    Label = "Class Taught:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.testDate.ToString(),
                    Label = "Test Date:",
                    Type = InputType.date.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                    Validation = true,
                    ValidationRequiredMessage = "The Test Date field is required!",
                    ValidationDateMessage = "A valid date must be entered"
                },
                new Input {
                    Id = InputIDType.description.ToString(),
                    Label = "Description:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.howWellKnown.ToString(),
                    Label = "How well do you know the student:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetKnownOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 2
                },
                new Input {
                    Id = InputIDType.howLongKnown.ToString(),
                    Label = "How long known (Months):",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                },
                new Input {
                    Id = InputIDType.specialEducation.ToString(),
                    Label = "Student receiving special educational services?:",
                    Type = InputType.checkbox.ToString(),
                    Options = Utility.GetYesNoOptions(),
                    Placeholder ="",
                    Class = "",
                    Column = 2
                },
                new Input {
                    Id = InputIDType.raterName.ToString(),
                    Label = "Examiner:",
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

