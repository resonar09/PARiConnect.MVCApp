using PARiConnect.MVCApp.Models.DynamicFormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System.Reflection;

namespace PARiConnect.MVCApp.Services
{
    public class DynamicFormData : IDynamicFormData
    {
        List<Input> _inputs;
        public DynamicFormData()
        {
            _inputs = new List<Input>
            {
                new Input {
                    Id = "email",
                    Label = "Email",
                    Type ="email",
                    Placeholder ="sample@email.com",
                    Class = "",
                    Width = "200",
                    Validation = true,
                    ValidationEmailMessage = "The Email Address field is not a valid email address.",
                    ValidationRequiredMessage = "The Email Address field is required!"
                },
                new Input {
                    Id = "password",
                    Label = "Password",
                    Type ="password",
                    Class = "",
                    Width = "300"
                },
            };
        }

        public Task<IEnumerable<Input>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Input>> GetListAsync()
        {

            return await Task.Run(() => _inputs);
        }
        public async Task<IEnumerable<Input>> GetInputsAsync(string model)
        {
            Type type = Assembly.GetEntryAssembly().GetType("PARiConnect.MVCApp.Models.DynamicFormModels."+ model);
            var modelInstance = Activator.CreateInstance(type);
            PropertyInfo inputsPropertyInfo = type.GetProperty("Inputs");
            IEnumerable<Input> inputs = (IEnumerable<Input>)inputsPropertyInfo.GetValue(modelInstance, null);

            return await Task.Run(() => inputs);
        }
        public async Task<Settings> GetSettingsAsync(string model)
        {
            Type type = Assembly.GetEntryAssembly().GetType("PARiConnect.MVCApp.Models.DynamicFormModels."+ model);
            var modelInstance = Activator.CreateInstance(type);
            PropertyInfo settingsPropertyInfo = type.GetProperty("Settings");
            Settings settings = (Settings)settingsPropertyInfo.GetValue(modelInstance, null);

            return await Task.Run(() => settings);
        }

    }
}

