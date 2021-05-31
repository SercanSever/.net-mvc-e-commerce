using ECommercial.Bussiness.DependencyResolvers.Ninject;
using ECommercial.Bussiness.MappingResolvers.AutoMapper;
using ECommercial.Core.Utilities.Mvc.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ECommercial.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(), new AutoMapperModule()));
            Application["OnlineUsers"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnlineUsers"] = (int)Application["OnlineUsers"] + 1;
            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["OnlineUsers"] = (int)Application["OnlineUsers"] - 1;
            Application.UnLock();
        }
    }
}
