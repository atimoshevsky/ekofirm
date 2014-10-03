
using BusinessLogic.Classes;
using BusinessLogic.Interfaces;
using DAL.Generic;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using MyOpportunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyOpportunity
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

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

            var container = new UnityContainer();

            container.RegisterType<IDALContext, DALContext>(new PerRequestLifetimeManager())
                .RegisterType<ICatalogService, CatalogService>()
                .RegisterType<IConnectionFactory, ConnectionFactory>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}