using System.Linq;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Pic.Auth.Data.Database;

namespace Pic.Auth.Service.DiModules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(AuthDbContext).Assembly;

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().Where(t => t.Name.EndsWith("Repository"));
            builder.RegisterType<AuthDbContext>().As<DbContext>().UsingConstructor();
        }
    }
}