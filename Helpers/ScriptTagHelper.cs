﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PARiConnect.MVCApp.Helpers
{
    [HtmlTargetElement("script", Attributes = "on-content-loaded")]
    public class ScriptTagHelper : TagHelper
    {
      /// <summary>
      /// Execute script only once document is loaded.
      /// </summary>
      public bool OnContentLoaded { get; set; } = false;

      public override void Process(TagHelperContext context, TagHelperOutput output)
      {
         if (!OnContentLoaded) base.Process(context, output);

         var content = output.GetChildContentAsync().Result;
         var javascript = content.GetContent();

         var sb = new StringBuilder();
         sb.Append("document.addEventListener('DOMContentLoaded',");
         sb.Append("function() {");
         sb.Append(javascript);
         sb.Append("});");

         output.Content.SetHtmlContent(sb.ToString());
      }
    }
}
