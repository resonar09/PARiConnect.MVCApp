using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Models.DynamicFormModels
{
    public interface IDynamicFormModel
    {
       string GetName();

       Task<IEnumerable<Input>> GetInputsAsync();

       Task<Settings> GetSettingsAsync();
    }
}
