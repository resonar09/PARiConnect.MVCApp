using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class GroupEdit : IDynamicFormModel
    {
        public List<Input> Inputs { get; set; }
        public Settings Settings { get; set; }
        private IGroupData _groupData;
        private readonly IUserService _userService;

        public GroupEdit(IUserService userService, IGroupData groupData)
        {
            _userService = userService;
            _groupData = groupData;
            Settings = new Settings();
            Settings.Layout = LayoutType.Stacked;
            Settings.Title = "Add/Edit Group";
            Settings.Container = ContainerType.Modal;
            Settings.ContainerName = "groupEditModal";
            Settings.Labels = true;
            Settings.FormController = "Groups";
            Settings.FormAction = "Update";
            Settings.FormSubmitText = "Add/Edit Group";
            Inputs = new List<Input>
            {
                new Input {
                    Id = "group",
                    Label = "Group:",
                    Type ="select",
                    Options = GetGroups(),
                    Placeholder ="",
                    Class = ""
                },
                new Input {
                    Id = "groupName",
                    Label = "Add/Edit Group Name:",
                    Type ="text",
                    Placeholder ="",
                    Class = "",
                    Validation = true,
                    ValidationRequiredMessage = "A group name is required!"
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
                optionList.Add(new Option(0, "Add a group", true));
                foreach (var group in _groupData.GetListAsync().Result)
                {
                    var option = new Option(group.ClientGroupKey, group.GroupName, false);
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

