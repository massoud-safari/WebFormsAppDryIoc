

using StructureMap;
using System;
using System.Diagnostics;
using System.Runtime.Remoting.Lifetime;
using WebApplication1.Services;

namespace WebApplication1.DI
{
    public class ApplicationContainerStructureMap
    {
        public static void Initialize()
        {

            var container = new Container(_ =>
            {
                _.For<ISingletonService>().Use<SingletonService>();
            });

            _serviceContainer = container;


            var oSingleton = container.GetInstance<ISingletonService>();
            Debug.WriteLine($"APPLICION SINGLETON : {oSingleton.ID}");



            var oSingleton2 = container.GetInstance<ISingletonService>();
            Debug.WriteLine($"APPLICION SINGLETON2 : {oSingleton2.ID}");

        }

        private static Container _serviceContainer;
        public static Container ServiceContainer { get { return _serviceContainer; } }
        public static string IDApp { get; set; } = Guid.NewGuid().ToString();
    }
}