using System;
using System.Reflection;
using Autofac;
using VokabelMnemonik.Controllers;
using VokabelMnemonik.Mapping;

namespace VokabelMnemonik.Modules
{
    public class MapperRegistrationsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsClosedTypesOf(typeof(IAmAMapper<>))
                .WithMetadata("key",ServiceNameMapping)
                .Named(ServiceNameMapping,typeof(IAmAMapper<>))
                .OwnedByLifetimeScope();

            builder.RegisterType<MapperResolver>().As<IResolveMapper>().OwnedByLifetimeScope();
          //_mapper = new MapperConfiguration(cfg => { cfg.AddProfile<VokabelHypermediaMapping>(); }).CreateMapper();
        }

        private static string ServiceNameMapping(Type type)
        {
            var name = type.Name.ToLower();
            return name;
        }
    }
}