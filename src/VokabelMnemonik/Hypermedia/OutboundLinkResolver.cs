using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Routing;
using Tavis.UriTemplates;

namespace VokabelMnemonik.Hypermedia
{
  public class OutboundLinkResolver
  {
    readonly Uri _baseUri;
    readonly RouteRegistrations _routes;

    public OutboundLinkResolver(Uri baseUri, RouteRegistrations routes)
    {
      _baseUri = baseUri;
      _routes = routes;
    }

    public OutboundLink Resolve<T>(T entity)
    {
      var route = _routes.Routes().FirstOrDefault(r => r.Name == "Vokabeln_GetAll");
      // var template = new UriTemplate(route.Template).SetParameter("title", entity.id).Resolve();
      return new OutboundLink(new UriBuilder(_baseUri.Scheme, _baseUri.Host, _baseUri.Port, route.Template).Uri, "Vokabeln");
    }
  }
}