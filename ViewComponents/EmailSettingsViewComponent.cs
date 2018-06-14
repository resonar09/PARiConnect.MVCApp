using Microsoft.AspNetCore.Mvc;
using PARiConnect.MVCApp.Services;
using PARiConnect.MVCApp.ViewModels;
using System.Linq;

namespace PARiConnect.MVCApp.ViewComponents
{
    public class EmailSettingsViewComponent : ViewComponent
    {
        private IEmailData _emailData;
        public EmailSettingsViewComponent(IEmailData emailData)
        {
            _emailData = emailData;
        }
        public IViewComponentResult Invoke()
        {
            var model = new EmailSettingsViewModel();
            var emailTemplates = _emailData.GetEmailTemplateByUserAsync().Result;
            model.EmailTemplates = emailTemplates;
            return View("EmailSettings", model);
        }
    }
}
