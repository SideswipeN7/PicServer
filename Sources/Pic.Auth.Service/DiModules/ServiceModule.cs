using System.Linq;
using Autofac;

namespace Pic.Auth.Service.DiModules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule).Assembly;

            builder.RegisterAssemblyTypes(assembly).Where(t => t.Name.EndsWith("Controller"));
        }
    }
}