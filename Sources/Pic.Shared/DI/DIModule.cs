using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Pic.Auth.DI
{
    public abstract class DIModule
    {
        public abstract void Load(IApplicationBuilder app, IWebHostEnvironment env);
    }
}