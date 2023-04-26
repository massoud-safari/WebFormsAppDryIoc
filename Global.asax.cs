using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication1.DI;

namespace WebApplication1
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeApplicationContainer();
            //DI.ApplicationContainerStructureMap.Initialize();
        }

        internal static void InitializeApplicationContainer()
        {
            ApplicationContainer.Initialize();
        }

    }
}