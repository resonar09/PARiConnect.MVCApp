using System.Collections.Generic;
using PARiConnect.MVCApp.Models;

namespace PARiConnect.MVCApp.ViewModels
{
    public class GroupViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
    }
}