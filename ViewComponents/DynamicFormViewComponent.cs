using Microsoft.AspNetCore.Mvc;
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
            var dynFormModel = _dynamicFormData.GetListAsync(model).Result;
            //var clients = _clientData.GetListAsync().Result;
            var viewmodel = new DynamicFormViewModel();
            viewmodel.Inputs = dynFormModel;
            return View("DynamicForm",viewmodel);
            //return null;
        }
    }
}
