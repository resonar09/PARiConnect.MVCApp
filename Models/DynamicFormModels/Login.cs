using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public class Login : IDynamicFormModel
    {

        public Settings Settings { get; set; }
        public List<Input> Inputs { get; set; }

        public Login()
        {
            Settings = new Settings();
            Settings.Layout = LayoutType.Stacked;
            Settings.Labels = false;
            Settings.FormController = "Auth";
            Settings.FormAction = "Login";
            Settings.FormSubmitText = "Add Client";
            Inputs = new List<Input>
            {
                new Input {
                    Id = "email",
                    Label = "Email",
                    Type ="email",
                    Placeholder ="sample@email.com",
                    PrePendIcon = "envelope-o",
                    Class = "",
                    Validation = true,
                    ValidationEmailMessage = "The Email Address field is not a valid email address.",
                    ValidationRequiredMessage = "The Email Address field is required!"
                },
                new Input {
                    Id = "password",
                    Label = "Password",
                    Type ="password",
                    PrePendIcon = "lock",
                    Class = "", 
                    Validation = true,
                    ValidationRequiredMessage = "The Password field is required!"
                },
            };
        }

        public string GetName()
        {
                return this.GetType().Name;
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