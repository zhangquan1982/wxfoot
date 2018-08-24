using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using HujingWeb.App_Start;
using System.Web.Compilation;

namespace HujingWeb
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
          

            #region Autofac  注入依赖 构造函数注入
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());//注册mvc容器的实现
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            builder.RegisterAssemblyTypes(assemblys.ToArray())//查找程序集中以Logic Access结尾的类型
            .Where(t => t.Name.Contains("Logic") || t.Name.Contains("Access"))
            .AsImplementedInterfaces();
    

            //// 注释此段代码
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(t => t.Name.EndsWith("Logic")).AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies()).Where(t => t.Name.EndsWith("Access")).AsImplementedInterfaces().PropertiesAutowired();


   
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//更改了MVC中的注入方式
            #endregion

            RegisterView();
        }

        protected void RegisterView()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new HujingViewEngine());
        }
    }


}