using Autofac;
using Pic.Auth.Logic.Models;

namespace Pic.Auth.Service.DiModules
{
    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(LogInModel).Assembly;

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().Where(t => t.Name.EndsWith("UseCase"));
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().Where(t => t.Name.EndsWith("Service"));
        }
    }
}