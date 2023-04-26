using DryIoc;
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
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var oTestService = ApplicationContainer.ServiceProvider.GetService<ITestServiceInjected>();

            Debug.WriteLine($"FIRST GET : ");
            Debug.WriteLine(oTestService.GetIDS());


            var oTestService2 = ApplicationContainer.ServiceProvider.GetService<ITestServiceInjected>();
            Debug.WriteLine($"SECOND GET : ");
            Debug.WriteLine(oTestService2.GetIDS());

            using (var scope = ApplicationContainer.Container.OpenScope())
            {
                var scoped1 = ApplicationContainer.Container.GetService<IScopeService>();
                Debug.WriteLine($"Scoped ID Contact = {scoped1.ID}");
            }
        }
    }
}