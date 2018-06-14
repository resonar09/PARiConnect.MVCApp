using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class DynamicFormViewComponent : ViewComponent
    {
        private IDynamicFormData _dynamicFormData;
        private readonly IClientData _clientData;

        public DynamicFormViewComponent(IDynamicFormData dynamicFormData, IClientData clientData)
        {
            _dynamicFormData = dynamicFormData;
            _clientData = clientData;
        }

        public IViewComponentResult Invoke(string model, int[] dataKeys, int displayType)
        {

            var dynFormModelInputs = _dynamicFormData.GetInputsAsync(model).Result;
            var dynFormModelSettings = _dynamicFormData.GetSettingsAsync(model).Result;
            //var clients = _clientData.GetListAsync().Result;
            var viewmodel = new DynamicFormViewModel();
            viewmodel.Inputs = dynFormModelInputs;
            if (dynFormModelSettings.Layout == LayoutType.Stacked)
            {
                dynFormModelSettings.Columns = 1;
            }
            else if (dynFormModelSettings.Layout == LayoutType.TwoColumn)
            {
                dynFormModelSettings.Columns = 2;
            }
            else if (dynFormModelSettings.Layout == LayoutType.Responsive)
            {
                dynFormModelSettings.Columns = 1;
            }
            else if (!(dynFormModelSettings.Columns > 0))
            {
                dynFormModelSettings.Columns = 1;
            }

            viewmodel.Settings = dynFormModelSettings;
            if (displayType == (int)DisplayType.Table)
            {
                viewmodel.Settings.Display = DisplayType.Table;
                var data = _clientData.GetClientsByKeysAsync(dataKeys).Result;
                var query = data.AsQueryable();
                foreach (var input in viewmodel.Inputs.Where(x => x.ClientData).OrderBy(o => o.ClientDataOrdinal))
                {
                    input.Data = query.Select(input.Id).Cast<string>().ToArray();
                }

                var inputKeys = viewmodel.Inputs.Where(x => x.ClientData).OrderBy(o => o.ClientDataOrdinal).Select(i => i.Id).ToArray();            
                //StringBuilder sb = new StringBuilder();
                //var query = data.AsQueryable();
                //var result = query.Select(select).Cast<Client>();
                viewmodel.DataColumns = inputKeys;
                viewmodel.DataRows = dataKeys;

            }
            else if (displayType == (int)DisplayType.ReadOnly)
            {
                viewmodel.Settings.Display = DisplayType.ReadOnly;
            }
            else
            {
                viewmodel.Settings.Display = DisplayType.Form;
            }

            if (viewmodel.Settings.Container == ContainerType.Modal)
                return View("DynamicFormModal", viewmodel);
            return View("DynamicForm", viewmodel);
        }
    }
}
