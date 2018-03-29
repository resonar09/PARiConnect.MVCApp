using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class ClinicianInvite : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }

        private readonly IUserService _userService;
        private readonly IPermissionData _permissionData;

        public ClinicianInvite(IUserService userService, IPermissionData permissionData)
        {
            _userService = userService;
            _permissionData = permissionData;
            Settings = new Settings();
            Settings.Layout = LayoutType.Custom;
            Settings.Title = "Add Clinician";
            Settings.Container = ContainerType.Modal;
            Settings.ContainerName = "clinicianAddModal";
            Settings.Labels = true;
            Settings.FormController = "Clinician";
            Settings.FormAction = "Invite";
            Settings.FormSubmitText = "Add Clinician";
            Inputs = new List<Input>
            {

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
                    Id = "emailAddress",
                    Label = "Primary Email:",
                    Type ="email",
                    Placeholder ="",
                    Class = "col-12",
                    Validation = true,
                    ValidationRequiredMessage = "The Email field is required!",
                    ValidationEmailMessage = "A valid Email is required!"
                },                
                new Input {
                    Id = "permissionProfile",
                    Label = "User Roles:",
                    Type ="select",
                    Options = GetUserRoles(),
                    OnChange = "getPermissions(this.value, 'Permission', 'GetPermissions')",
                    Placeholder ="",
                    Class = "col-8"
                },
                new Input {
                    Id = "permissions",
                    Label = "Permissions:",
                    Type ="list",
                    List = GetPermissions(),
                    Class = "col-12",
                    Validation = true,
                    ValidationRequiredMessage = "The permission list is required!"
                }

            };
        }
        public string GetName()
        {
            return this.GetType().Name;
        }
        public IEnumerable<Option> GetUserRoles()
        {
            var optionList = new List<Option>();
            if (!string.IsNullOrEmpty(_userService.GetCurrentUserId()))
            {
                optionList.Add(new Option(0, "Choose a user role", true));
                foreach (var permProfile in _permissionData.GetPermissionProfileListAsync().Result)
                {
                    if(permProfile.DisplayOrder > 0)
                    {
                        var option = new Option(permProfile.PermissionProfileKey, permProfile.PermissionProfileName, false);
                        optionList.Add(option);
                    }

                }
            }
            return optionList;
        }
        public IEnumerable<Input> GetPermissions()
        {
            var inputList = new List<Input>();
            
            if (!string.IsNullOrEmpty(_userService.GetCurrentUserId()))
            {

                //optionList.Add(new Option(0, "Choose a user role", true));
                //var input = new Input();
                foreach (var perm in _permissionData.GetPermissionListAsync().Result)
                {
                    var optionList = new List<Option>();
                    var input = new Input();
                    input.Id = perm.PermissionID;
                    input.Label = perm.PermissionName;
                    input.Type = "radio";
                    input.Validation = true;
                    input.ValidationRequiredMessage = "You must choose permissions";
                    if(perm.PermissionOption == "2 Option")
                    {
                        optionList.Add(new Option(2, "Yes", false));
                        optionList.Add(new Option(0, "No", false));
                    }
                    if(perm.PermissionOption == "3 Option")
                    {
                        optionList.Add(new Option(2, "All", false));
                        optionList.Add(new Option(1, "Own", false));
                        optionList.Add(new Option(0, "None", false));
                    }
                    input.Options = optionList;
                    inputList.Add(input);
                }

            }
            return inputList;
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

