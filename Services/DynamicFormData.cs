using PARiConnect.MVCApp.Models.DynamicFormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace PARiConnect.MVCApp.Services
{
    public class DynamicFormData : IDynamicFormData
    {
        //List<Input> _inputs;

        private IServiceProvider _serviceProvider;

        public DynamicFormData(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<IEnumerable<Input>> GetInputsAsync(string model)
        {
            var modelServices = _serviceProvider.GetServices<IDynamicFormModel>();
            var modelService = modelServices.First(o => o.GetName() == model);
            return modelService.GetInputsAsync();
        }

        public Task<Settings> GetSettingsAsync(string model)
        {
            var modelServices = _serviceProvider.GetServices<IDynamicFormModel>();
            var modelService = modelServices.First(o => o.GetName() == model);
            
            return modelService.GetSettingsAsync();
        }
/*         public async Task<IEnumerable<Input>> GetInputsAsync(string model)
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
        } */


    }
}

