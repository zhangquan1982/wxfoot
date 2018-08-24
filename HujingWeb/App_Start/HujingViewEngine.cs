using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.App_Start
{
    public class HujingViewEngine : RazorViewEngine
    {
        public HujingViewEngine()
        {
            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/SysFrame/{1}/{0}.cshtml", 
                "~/Views/Basic/{1}/{0}.cshtml",
                "~/Views/PatiOut/{1}/{0}.cshtml",
                "~/Views/OldPerson/{1}/{0}.cshtml",
                "~/Views/Storage/{1}/{0}.cshtml",
                "~/Views/Nurse/{1}/{0}.cshtml",
                "~/Views/Doctor/{1}/{0}.cshtml",
                 "~/Views/PatiInOrder/{1}/{0}.cshtml",
                "~/Views/ChargeManager/{1}/{0}.cshtml",
                "~/Views/ReportView/{1}/{0}.cshtml",
                "~/Views/OrgApply/{1}/{0}.cshtml",
                "~/Views/EMR/{1}/{0}.cshtml",
                "~/Views/Device/{1}/{0}.cshtml",
                "~/Views/WXUserRole/{1}/{0}.cshtml",
                "~/Views/Patient/{1}/{0}.cshtml"//我们的规则
            };
        }


        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}