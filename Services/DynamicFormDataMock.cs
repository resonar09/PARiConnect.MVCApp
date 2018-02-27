
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using PARiConnect.MVCApp.Models.DynamicFormModels;

namespace PARiConnect.MVCApp.Services
{
    public class DynamicFormDataMock : IDynamicFormData
    {
        List<Input> _inputs;
        public DynamicFormDataMock()
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
        public async Task<IEnumerable<Input>> GetListAsync(string model)
        {
            Type type = Assembly.GetEntryAssembly().GetType("PARiConnect.MVCApp.Models.DynamicFormModels."+ model);
 
            var modelInstance = Activator.CreateInstance(type);
            //var object = type.InvokeMember("GetModel", new IEnumerable<Input> input);
            PropertyInfo inputsPropertyInfo = type.GetProperty("Inputs");
            IEnumerable<Input> inputs = (IEnumerable<Input>)inputsPropertyInfo.GetValue(modelInstance, null);

            return await Task.Run(() => inputs);
        }

        Task<IEnumerable<Input>> IDynamicFormData.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Input>> IDynamicFormData.GetListAsync()
        {
            throw new NotImplementedException();
        }
    }
}

