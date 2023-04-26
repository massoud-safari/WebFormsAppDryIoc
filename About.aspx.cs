using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DI;
using WebApplication1.Services;

namespace WebApplication1
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var oService = DI.ApplicationContainer.ServiceProvider.GetService<ISingletonService>();
            Debug.WriteLine($"SIGNLETON ID : {oService.ID}");

            var oServiceScope = ApplicationContainer.ServiceProvider.GetService<IScopeService>();
            Debug.WriteLine($"SCOPE ID : {oServiceScope.ID}");

            var oServiceTransien = ApplicationContainer.ServiceProvider.GetService<ITransienService>();
            Debug.WriteLine($"Transine ID : {oServiceTransien.ID}");

            Debug.WriteLine($"**************************************");

            var oServiceScope2 = ApplicationContainer.ServiceProvider.GetService<IScopeService>();
            Debug.WriteLine($"SCOPE2 ID : {oServiceScope2.ID}");

            var oServiceTransien2 = ApplicationContainer.ServiceProvider.GetService<ITransienService>();
            Debug.WriteLine($"Transine2 ID : {oServiceTransien2.ID}");

        }
    }
}