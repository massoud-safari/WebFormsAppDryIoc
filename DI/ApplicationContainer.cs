using DryIoc;
using DryIoc.Web;
using System;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.DI
{
    public class ApplicationContainer
    {
        public static void Initialize()
        {
            // demonstrate simultaneous use of Http Scope context and Thread Scope context. because we may use Task.Run() in our code.
            // actually, we used Task.Run() in our code many times and we can not refactor or change that code.
            // but we need to have HttpContext scopes too so that our services resolved in Scoped reuse because we have Entity Framework DBContext and we 
            // want the DBContext to be instantiated in each scope rather than to be singleton (which is not a right choice to be in a web application) or Transient.

            //var container = new Container(rules => rules.WithoutThrowOnRegisteringDisposableTransient());
            Container = new Container().WithHttpContextScopeContext().With(scopeContext: new ThreadScopeContext());
            Container.Register<ISingletonService, SingletonService>(reuse: Reuse.Singleton);
            Container.Register<ITransienService, TransienService>(reuse: Reuse.Transient);

            // could we define a service resolution in different Reuses ?
            // what solution do you have for this in DryIOC ?

            Container.Register<IScopeService, ScopeService>(reuse: Reuse.Scoped);
            Container.Register<IScopeService, ScopeService>(reuse: Reuse.InThread);

            Container.Register<ITestServiceInjected, TestServiceInjectede>(reuse: Reuse.Transient);

            //Container.regis

            _serviceProvider = Container.OpenScope();

            // a sample use case of a Task.Run() that needs to be DI aware simultaneously with HttpContext Scope.
            Task.Run(() =>
            {
                var x = ServiceProvider.GetService<IScopeService>();

            });
        }

        public static IContainer Container;
        private static IServiceProvider _serviceProvider;
        public static IServiceProvider ServiceProvider { get { return _serviceProvider; } }
    }



}