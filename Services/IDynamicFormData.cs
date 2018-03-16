using PARiConnect.MVCApp.Models.DynamicFormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IDynamicFormData
    {
       Task<IEnumerable<Input>> GetInputsAsync(string model);
       Task<Settings> GetSettingsAsync(string model);
    }
}
