﻿using ForumForGeeksForLess.Models;
using ForumForGeeksForLess.Models.DBModel;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ForumForGeeksForLess
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();

            Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());
            Database.SetInitializer<ForumForGeeksForLessBD>(new DataLevelDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
