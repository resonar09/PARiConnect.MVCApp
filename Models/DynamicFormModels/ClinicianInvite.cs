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
            Settings.FormController = "Clients";
            Settings.FormAction = "Create";
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
                    Id = "primaryEmail",
                    Label = "Primary Email:",
                    Type ="email",
                    Placeholder ="",
                    Class = "col-12",
                    Validation = false,
                    ValidationEmailMessage = "A valid email is required!"
                },                
                new Input {
                    Id = "userRoles",
                    Label = "User Roles:",
                    Type ="select",
                    Options = GetUserRoles(),
                    Placeholder ="",
                    Class = "col-6"
                },
                new Input {
                    Id = "permissionProfile",
                    Label = "Permissions:",
                    Type ="list",
                    List = new[] {new Input { Id = "PURCHASE_INVENTORY", Label = "Ability to purchase:", Type ="radio", Options = new[] {new Option(1,"Yes",true), new Option(2,"No",false)}},
                                  new Input { Id = "ALLOCATE_INVENTORY", Label = "Ability to allocate uses:", Type ="radio", Options = new[] {new Option(1,"Yes",true), new Option(2,"No",false)}}
                                 },
                    Class = "col-12",
                    Validation = true,
                    ValidationRequiredMessage = "The Last Name field is required!"
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
                foreach (var permProfile in _permissionData.GetPermissionProfilesAsync().Result)
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

