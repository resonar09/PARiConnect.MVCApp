using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Models.DynamicFormModels;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class DynamicFormViewComponent : ViewComponent
    {
        private IDynamicFormData _dynamicFormData;

        public DynamicFormViewComponent(IDynamicFormData dynamicFormData)
        {
            _dynamicFormData = dynamicFormData;
        }

        public IViewComponentResult Invoke(string model)
        {
            
            var dynFormModelInputs = _dynamicFormData.GetInputsAsync(model).Result;
            var dynFormModelSettings = _dynamicFormData.GetSettingsAsync(model).Result;
            //var clients = _clientData.GetListAsync().Result;
            var viewmodel = new DynamicFormViewModel();
            
            viewmodel.Inputs = dynFormModelInputs;
            if(dynFormModelSettings.Layout == LayoutType.Stacked){
                dynFormModelSettings.Columns = 1;
            }
            else if(dynFormModelSettings.Layout == LayoutType.TwoColumn){
                dynFormModelSettings.Columns = 2;
            }
            else if(dynFormModelSettings.Layout == LayoutType.Responsive){
                dynFormModelSettings.Columns = 1;
            }
            else if(!(dynFormModelSettings.Columns > 0)){
                dynFormModelSettings.Columns = 1;
            }
            viewmodel.Settings = dynFormModelSettings;
            if(viewmodel.Settings.Container == ContainerType.Modal)
                return View("DynamicFormModal",viewmodel);
            return View("DynamicForm",viewmodel);
        }
    }
}
