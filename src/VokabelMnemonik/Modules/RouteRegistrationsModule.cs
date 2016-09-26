using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace VokabelMnemonik.Modules
{
  public class RouteRegistrationsModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder
        .RegisterAssemblyTypes(Assembly.GetEntryAssembly())
        .Where(t => typeof(IRegisterRoutes)
          .IsAssignableFrom(t))
        .InstancePerLifetimeScope()
        .AsImplementedInterfaces();

      builder
        .RegisterType<RouteRegistry>()
        .As<IRouteRegistry>();
    }
  }
}