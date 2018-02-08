﻿using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IClinicianData
    {
       Task<IEnumerable<Clinician>> GetAll();
       Task<IEnumerable<Clinician>> GetListAsync();
    }
}
