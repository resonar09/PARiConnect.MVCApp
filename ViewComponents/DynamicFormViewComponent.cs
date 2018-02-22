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
        public IViewComponentResult Invoke()
        {
            var model = new DynamicFormViewModel();
            var dynForm = _dynamicFormData.GetListAsync().Result;
            //var clients = _clientData.GetListAsync().Result;
            model.Inputs = dynForm;
            return View("DynamicForm", model);
            //return null;
        }
    }
}
