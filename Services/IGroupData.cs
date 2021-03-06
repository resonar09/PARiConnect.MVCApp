﻿using CoreServiceDevReference;
using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IGroupData
    {

       Task<IEnumerable<Group>> GetListAsync();

       Task<ClientGroup> GetByKeyAsync(int key);

       Task<CoreServiceDevReference.ClientGroup> SaveOrUpdate(CoreServiceDevReference.ClientGroup clientGroup);
    }
}
