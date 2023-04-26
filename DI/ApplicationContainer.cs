using DryIoc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WebApplication1.Services;

namespace WebApplication1.DI
{
    public class ApplicationContainer
    {
        public static void Initialize()
        {

            //var container = new Container(rules => rules.WithoutThrowOnRegisteringDisposableTransient());
            Container = new Container();
            Container.Register<ISingletonService, SingletonService>(reuse: Reuse.Singleton);
            Container.Register<ITransienService, TransienService>(reuse: Reuse.Transient);
            Container.Register<IScopeService, ScopeService>(reuse: Reuse.Scoped);

            Container.Register<ITestServiceInjected, TestServiceInjectede>(reuse: Reuse.Transient);

            //Container.regis
           
            _serviceProvider = Container.OpenScope();



        }

        public static Container Container;
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider { get { return _serviceProvider; } }
    }



}