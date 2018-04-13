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
            Settings.Layout = LayoutType.Stacked;
            Settings.Container = ContainerType.Modal;
            Settings.ContainerName = "cabModal";
            Settings.Columns = 1;
            Settings.Title = "CAB Demographics";
            Settings.FormSubmitText = "Submit";
            Settings.Labels = true;
            Settings.FormController = "Demographics";
            Settings.FormAction = "Index";
            Inputs = new List<Input>
            {
                new Input {
                    Id = "testDate",
                    Label = "Test Date:",
                    Type ="date",
                    //Column = 1,
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
                    //Column = 1,
                    Options = new[] {new Option(1,"Female",false), new Option(2, "Male", false)},
                    Placeholder ="",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The gender field is required!"
                },
                new Input {
                    Id = "firstName",
                    Label = "First Name:",
                    Type ="text",
                    //Column = 1,
                    Placeholder ="Jerry",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                },
                new Input {
                    Id = "grade",
                    Label = "Grade:",
                    Type ="select",
                    //Column = 1,
                    Options = new[] {new Option(0,"Not Specified",true),new Option(1,"1st",false), new Option(2,"2nd",false), new Option(3,"3rd",false), new Option(4,"4th",false), new Option(5,"5th",false), new Option(6,"6th",false), new Option(7,"7th",false), new Option(8,"8th",false), new Option(9,"9th",false), new Option(10,"10th",false), new Option(11,"11th",false), new Option(12,"12th",false), new Option(13,"College",false)},
                    Placeholder ="",
                    Class = ""
                },
                new Input {
                    Id = "lastName",
                    Label = "Last Name:",
                    Type ="text",
                    //Column = 1,
                    Placeholder ="Nolan",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
                },
                new Input {
                    Id = "raterName",
                    Label = "Rater Name:",
                    Type ="text",
                    //Column = 1,
                    Placeholder ="Nolan",
                    Class = "",
                    Validation = false
                },
                new Input {
                    Id = "clientID",
                    Label = "Client Id:",
                    Type ="text",
                    //Column = 1,
                    Placeholder ="123abc",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },
                new Input {
                    Id = "relationship",
                    Label = "Relationship To Child:",
                    Type ="select",
                    //Column = 1,
                    Options = new[] {new Option(0,"Not Specified",true),new Option(1,"Mother",false), new Option(2,"Father",false), new Option(3,"Other",false)},
                    Placeholder ="",
                    Class = ""
                },

                new Input {
                    Id = "dob",
                    Label = "Birthdate:",
                    Type ="date",
                    //Column = 1,
                    Placeholder ="",
                    Class = "",
                },
                new Input {
                    Id = "age",
                    Label = "Age:",
                    Type ="text",
                    //Column = 1,
                    Placeholder ="",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The Age field is required!"
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

