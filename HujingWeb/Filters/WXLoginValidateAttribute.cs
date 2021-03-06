﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HujingWeb.Filter
{
    public class WXLoginValidateAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 如果请求的区域包含area. 那么就进行权限验证。
        /// </summary>
        /// <param name="fiterContext"></param>
        public override void OnAuthorization(AuthorizationContext fiterContext)
        {

            if (fiterContext.HttpContext.Response.StatusCode == 403)
            {
                fiterContext.Result = new RedirectResult("/WXHome/Index");

            }
            base.OnAuthorization(fiterContext);
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if ((httpContext.Request.Cookies["PatiID"] == null) || ( httpContext.Request.Cookies["PatiName"] == null) )
            {
                return false;
            }
            else
            {
                return true;
            }
            //return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            else
            {
                ContentResult content = new ContentResult();
                content.Content = string.Format("<script language='javaScript' type='text/javaScript'>window.location.href = '/WXHome/Login';</script>");
                filterContext.Result = content;
                return;
            }

        }
    }
}