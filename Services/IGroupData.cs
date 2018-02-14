using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IGroupData
    {
       Task<IEnumerable<Group>> GetAll();
       Task<IEnumerable<Group>> GetListAsync();
    }
}
