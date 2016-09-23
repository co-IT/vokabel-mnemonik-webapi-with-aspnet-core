using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VokabelMnemonik.Hypermedia;

namespace VokabelMnemonik
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

      if (env.IsEnvironment("Development"))
      {
        // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
        builder.AddApplicationInsightsSettings(true);
      }

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {
      // Add framework services.
      services.AddApplicationInsightsTelemetry(Configuration);

      services.AddSingleton<IRouteRegistrations, RouteRegistrations>();
      services.AddSingleton(new OutboundLinkResolver(new Uri("http://localhost"), new RouteRegistrations()));
      services.AddCors();
      services.AddMvc();
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

      Action<IRouteBuilder> configureRoutes = routes =>
      {
        new RouteRegistrations().Routes().ToList().ForEach(route => routes.MapRoute(
          route.Name,
          route.Template,
          new {controller = route.Controller, action = route.Action}
          ));
      };

      app.UseMvc(configureRoutes);
    }
  }

  public interface IRouteRegistrations
  {
    IEnumerable<RouteRegistration> Routes();
  }

  public class RouteRegistrations : IRouteRegistrations
  {
    public IEnumerable<RouteRegistration> Routes()
    {
      yield return new RouteRegistration
      {
        Name = "Vokabeln_GetAll",
        Template = "vokabeln",
        Controller = "Vokabeln",
        Action = "GetAll"
      };

      yield return new RouteRegistration
      {
        Name = "Vokabeln_GetById",
        Template = "vokabeln",
        Controller = "Vokabeln",
        Action = "GetById"
      };

      yield return new RouteRegistration
      {
        Name = "Vokabeln_Anlegen",
        Template = "vokabeln",
        Controller = "Vokabeln",
        Action = "Anlegen"
      };
    }
  }

  public class RouteRegistration
  {
    public string Name { set; get; }
    public string Template { set; get; }
    public string Controller { set; get; }
    public string Action { set; get; }
  }
}