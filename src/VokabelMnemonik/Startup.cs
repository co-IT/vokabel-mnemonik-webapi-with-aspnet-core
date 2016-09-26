using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VokabelMnemonik.Mapping;

namespace VokabelMnemonik
{
  public class Startup
  {
    IContainer _container;
    IMvcBuilder _mvcBuilder;


    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

      if (env.IsDevelopment())
        builder.AddApplicationInsightsSettings(true);

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddApplicationInsightsTelemetry(Configuration);
      services.AddCors();
      _mvcBuilder = services.AddMvc();

      var containerBuilder = new ContainerBuilder();
      containerBuilder.RegisterAssemblyModules(Assembly.GetEntryAssembly());
      containerBuilder.Populate(services);

      _container = containerBuilder.Build();

      DebugRegistrations();

      var mapperResolver = _container.Resolve<IResolveMapper>();
      var formatter = new VokabelToSirenAsJsonFormatter(mapperResolver);

      _mvcBuilder.AddMvcOptions(options =>
      {
        options.OutputFormatters.Add(formatter);
      });

      return new AutofacServiceProvider(_container);
    }

    void DebugRegistrations()
    {
      _container.ComponentRegistry.Registrations.ToList().ForEach(reg =>
      {
        reg.Target.Services.ToList().ForEach(tserv =>
        {
          var desc = tserv.Description;
          if (desc.ToLower().StartsWith("vokabelmnemonik"))
            Console.WriteLine(desc);
        });

        reg.Services.ToList().ForEach(serv =>
        {
          var desc = serv.Description;
          if (desc.ToLower().StartsWith("vokabelmnemonik"))
            Console.WriteLine(desc);
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      app.UseApplicationInsightsRequestTelemetry();

      app.UseApplicationInsightsExceptionTelemetry();

      app.UseCors(builder =>
        builder.WithOrigins("http://localhost:4200")
          .AllowAnyMethod()
          .AllowAnyHeader()
        );

      var routeConfigurations = RouteConfigurations();
      app.UseMvc(routeConfigurations);
    }

    Action<IRouteBuilder> RouteConfigurations()
    {
      var allRoutes = _container.Resolve<IRouteRegistry>().Routes();

      Action<IRouteBuilder> routeConfigurations = routes =>
      {
        allRoutes.ToList().ForEach(route => routes.MapRoute(
          route.Name,
          route.Template,
          new {controller = route.Controller, action = route.Action}
          ));
      };

      return routeConfigurations;
    }
  }
}