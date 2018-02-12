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
    public class ClinicianDataMock : IClinicianData
    {
        List<Clinician> _clinicians;
        public ClinicianDataMock()
        {
            _clinicians = new List<Clinician>
            {
                new Clinician {
                    OrgUserMappingKey = 1,
                    Name ="Roaming Crowder"
                }
            };
        }

        public Task<IEnumerable<Clinician>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Clinician>> GetListAsync()
        {

            return await Task.Run(() => _clinicians);
        }
    }
}

