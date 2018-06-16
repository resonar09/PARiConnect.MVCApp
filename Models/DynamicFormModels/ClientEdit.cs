using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class ClientEdit : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }
        private IGroupData _groupData;
        private readonly IUserService _userService;

        public ClientEdit(IUserService userService, IGroupData groupData)
        {
            _userService = userService;
            _groupData = groupData;
            Settings = new Settings();
            Settings.Layout = LayoutType.TwoColumn;
            Settings.Container = ContainerType.Modal;
            Settings.Columns = 2;
            Settings.Title = "Add/Edit Client";
            Settings.ContainerName = "clientEditModal";
            Settings.Labels = true;
            Settings.FormController = "Clients";
            Settings.FormAction = "Create";
            Settings.FormSubmitText = "Add Client";

            Inputs = new List<Input>
            {
                new Input {
                    Id = InputIDType.clientId.ToString(),
                    Label = "Client Id:",
                    Type = InputType.text.ToString(),
                    Placeholder ="123abc",
                    Column = 1,
                    Class = "",
                    //PrePendIcon = "address-card",
                    Validation = true,
                    ValidationRequiredMessage = "The Client ID field is required!"
                },
                new Input {
                    Id = InputIDType.firstName.ToString(),
                    Label = "First Name:",
                    Type = InputType.text.ToString(),
                    Placeholder ="Jerry",
                    Column = 1,
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The First Name field is required!"
                },
                new Input {
                    Id = InputIDType.lastName.ToString(),
                    Label = "Last Name:",
                    Type = InputType.text.ToString(),
                    Placeholder ="Nolan",
                    Column = 1,
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
                },
                new Input {
                    Id = InputIDType.dateOfBirth.ToString(),
                    Label = "Birthday:",
                    Type = InputType.date.ToString(),
                    Placeholder ="",
                    Column = 1,
                    Class = "",
                    Validation = false,
                    ValidationDateMessage = "A valid date is required!"
                },
                new Input {
                    Id = InputIDType.age.ToString(),
                    Label = "Age",
                    Type = InputType.number.ToString(),
                    Min = 0,
                    Max = 120,
                    Placeholder ="",
                    Column = 1,
                    Class = "",
                    Validation = true,
                    ValidationNumberMessage = "A valid age is required!"
                },
                new Input {
                    Id = InputIDType.gender.ToString(),
                    Label = "Gender",
                    Type = InputType.select.ToString(),
                    Options = Utility.GetGender2Options(),
                    Column = 2,
                    Class = ""
                },
                new Input {
                    Id = InputIDType.normGroup.ToString(),
                    Label = "Group:",
                    Type = InputType.select.ToString(),
                    Options = GetGroups(),
                    Column = 2,
                    Class = ""
                },
                new Input {
                    Id = InputIDType.primaryEmail.ToString(),
                    Label = "Primary Email:",
                    Type = InputType.email.ToString(),
                    Placeholder ="",
                    Class = "",
                    Column = 2,
                    Validation = false,
                    ValidationEmailMessage = "A valid email is required!"
                },
                new Input {
                    Id = InputIDType.secondaryEmail.ToString(),
                    Label = "Secondary Email:",
                    Type = InputType.email.ToString(),
                    Placeholder ="",
                    Column = 2,
                    Class = "",
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
            if (!string.IsNullOrEmpty(_userService.GetCurrentUserId()))
            {
                optionList.Add(new Option(0, "Choose a group", true));
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

