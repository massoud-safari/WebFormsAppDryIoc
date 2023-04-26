using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class TransienService : ITransienService
    {
        public TransienService()
        {
            ID = Guid.NewGuid().ToString();
        }
        public string ID { get; private set; }

    }
}