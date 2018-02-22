using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;

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
        public async Task<IEnumerable<Input>> GetListAsync(string model)
        {
            Type t = Type.GetType("CAD");
            
            return await Task.Run(() => (IEnumerable<Input>)t);
        }
    }
}

