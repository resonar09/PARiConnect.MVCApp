using System;
using System.Collections.Generic;
using System.Linq;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;

namespace PARiConnect.MVCApp.ViewModels
{
    public class DynamicFormViewModel
    {


        public Settings Settings { get; set; }

        public IEnumerable<Input> Inputs { get; set; }


        public string[] DataColumns { get; set; }
        public int[] DataRows { get; set; }

    }


}