using DryIoc;
using System;
using System.Diagnostics;
using System.Web.UI;
using WebApplication1.DI;
using WebApplication1.Services;

namespace WebApplication1
{
    public partial class _Default : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var scope = ApplicationContainer.Container.OpenScope())
            {
                var scoped1 = ApplicationContainer.Container.GetService<IScopeService>();
                Debug.WriteLine($"Scoped ID Default = {scoped1.ID}");
            }
        }
    }
}