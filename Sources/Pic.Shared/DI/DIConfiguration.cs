using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Pic.Auth.DI;

namespace Pic.Shared.DI
{
    public class DIConfiguration : DIModule
    {
        private readonly List<DIModule> modules = new List<DIModule>();

        public override void Load(IApplicationBuilder app, IWebHostEnvironment env)
        {
            foreach(var module in modules)
            {
                module.Load(app, env);
            }
        }

        protected void Add(DIModule diModule) => modules.Add(diModule);
    }
}