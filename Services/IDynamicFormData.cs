using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IDynamicFormData
    {
       Task<IEnumerable<Input>> GetAll();
       Task<IEnumerable<Input>> GetListAsync();
    }
}
