using PARiConnect.MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PARiConnect.MVCApp.Services
{
    public interface IReportData
    {
        Task<IEnumerable<Report>> GetAll();
        Task<IEnumerable<Report>> GetListAsync();
    }
}
