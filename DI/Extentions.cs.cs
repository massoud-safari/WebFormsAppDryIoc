using System;

namespace WebApplication1.DI
{
    public static class Extentions
    {
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)DI.ApplicationContainer.ServiceProvider.GetService(typeof(T));
        }
    }
}