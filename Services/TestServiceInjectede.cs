using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    internal class TestServiceInjectede : ITestServiceInjected
    {
        private readonly ISingletonService _singletonService;
        private readonly ITransienService _transienService;
        private readonly IScopeService _scopeService;

        public TestServiceInjectede(IScopeService scopeService, ITransienService transienService, ISingletonService singletonService)
        {
            _scopeService = scopeService;
            _transienService = transienService;
            _singletonService = singletonService;
        }

        public string GetIDS()
        {
            return $"SINGLETON : {_singletonService.ID}\n" +
                $"SCOPE : {_scopeService.ID}\n" +
                $"TRANSIENT : {_transienService.ID}\n" +
                $"*********************************";
        }
    }
}