using CoreServiceDevReference;
using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IClientData
    {
       Task<IEnumerable<Models.Client>> GetListAsync();
       Task<CoreServiceDevReference.Client> SaveOrUpdate(CoreServiceDevReference.Client client, CoreServiceDevReference.ClientGroup clientGroup);
    }
}
