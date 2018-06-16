using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class BRIEF2_3112 : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }
        private IGroupData _groupData;
        
        public BRIEF2_3112(IGroupData groupData) 
        {
             _groupData = groupData;
            Settings = new Settings();
            Settings.Layout = LayoutType.TwoColumn;
            Settings.Container = ContainerType.Page;
            Settings.ContainerName = "brief2Modal";
            Settings.Columns = 2;
            Settings.Title = "BRIEF2 Teacher Form Demographics";
            Settings.FormSubmitText = "Submit";
            Settings.Labels = true;
            Settings.FormController = "";
            Settings.FormAction = "";
            Settings.ShowValidation = false;
            Settings.Display = DisplayType.Table;
            Inputs = new List<Input>
            {
            
                new Input {
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
                    Label = "Student's First Name:",
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
                    Label = "Student's Last Name:",
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
                    Label = "Id Number:",
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
                    Id = InputIDType.dateOfBirth.ToString(),
                    Label = "Birthdate:",
                    Type = InputType.date.ToString(),
                    Placeholder ="",
                    Class = "form-control-sm",
                    Column = 1,
                    ClientData = true,
                    ClientDataOrdinal = 4,
                },
                new Input {
                    Id = InputIDType.age.ToString(),
                    Label = "Age:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "form-control-sm",
                    Max=18,
                    Min=5,
                    Column = 1,
                    ClientData = true,
                    TestDataOrdinal = 3,
                    ClientDataValidation = true,
                    ValidationRequiredMessage = "The Age field is required!"
                },
                new Input {
                    Id = InputIDType.gender.ToString(),
                    Label = "Gender:",
                    Type = InputType.radio.ToString(),
                    Options = Utility.GetGenderOptions(),
                    Placeholder ="",
                    Class = "form-control-sm",
                    Column = 1,
                    ClientData = true,
                    ClientDataOrdinal = 5,
                    ClientDataValidation = true,
                },
                new Input {
                    Id = InputIDType.grade.ToString(),
                    Label = "Grade:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetGradeOptions(),
                    Placeholder ="",
                    Class = "form-control-sm",
                    Column = 2,
                    Value = "0", //Default to Not Specified
                    ClientData = false,
                    TestDataOrdinal = 6
                },
                new Input {
                    Id = InputIDType.raterName.ToString(),
                    Label = "Rater Name:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "form-control-sm",
                    Column = 2,
                    ClientData = false,
                    TestDataOrdinal = 7
                },
                new Input {
                    Id = InputIDType.relationship.ToString(),
                    Label = "Relationship To Student:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetTeacherRelationshipOptions(),
                    Placeholder ="",
                    Class = "form-control-sm",
                    Value = "0", //Default to Not Specified
                    Column = 2,
                    ClientData = false,
                    TestDataOrdinal = 8
                },
                new Input {
                    Id = InputIDType.classTaught.ToString(),
                    Label = "Class Taught:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "form-control-sm",
                    Column = 2,
                    ClientData = false,
                    TestDataOrdinal = 9
                },
                new Input {
                    Id = InputIDType.testDate.ToString(),
                    Label = "Test Date:",
                    Type = InputType.date.ToString(),
                    Placeholder ="",
                    Class = "form-control-sm",
                    Column = 2,
                    ClientData = false,
                    TestDataOrdinal = 2
                },
                new Input {
                    Id = InputIDType.description.ToString(),
                    Label = "Description:",
                    Type = InputType.text.ToString(),
                    Placeholder ="",
                    Class = "form-control-sm",
                    Column = 2,
                    ClientData = false,
                    TestDataOrdinal = 5
                },
                new Input {
                    Id = InputIDType.howWellKnown.ToString(),
                    Label = "How well do you know the student:",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetKnownOptions(),
					Class = "form-control-sm",
                    Value = "0", //Default to Not Specified
                    Column = 2,
                    ClientData = false,
                    TestDataOrdinal = 10
                },
                new Input {
                    Id = InputIDType.howLongKnown.ToString(),
                    Label = "How long known (Months):",
                    Type = InputType.text.ToString(),
                    Class = "form-control-sm",
                    Column = 2,
                    ClientData = false,
                    TestDataOrdinal = 11
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
                    Class = "form-control-sm",
                    Column = 2,
                    ClientData = false,
                    TestDataOrdinal = 4
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

