using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MedixCollege.Helpers
{
    public class AjaxAwareRedirectResult : RedirectResult
    {
        public AjaxAwareRedirectResult(String url)
            : base(url)
        {
        }

        public override void ExecuteResult(ControllerContext context)
        {
            String destinationUrl = UrlHelper.GenerateContentUrl(Url, context.HttpContext);

            JavaScriptResult result = new JavaScriptResult()
            {
                Script = "window.location='" + destinationUrl + "';"
            };
            result.ExecuteResult(context);
        }
    }
}
