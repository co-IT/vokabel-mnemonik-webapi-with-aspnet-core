using System;
using System.Linq;
using VokabelMnemonik.Controllers;

namespace VokabelMnemonik.Hypermedia
{
    public class OutboundLinkResolver
    {
        private readonly Uri _baseUri;
        private readonly VokabelnControllerRoutes _routes;

        public OutboundLinkResolver(Uri baseUri, VokabelnControllerRoutes routes)
        {
            _baseUri = baseUri;
            _routes = routes;
        }

        public OutboundLink Resolve<T>(T entity)
        {
            var route = _routes.Routes().FirstOrDefault(r => r.Name == "Vokabeln_GetAll");
            // var template = new UriTemplate(route.Template).SetParameter("title", entity.id).Resolve();
            return new OutboundLink(new UriBuilder(_baseUri.Scheme, _baseUri.Host, _baseUri.Port, route.Template).Uri,
                "Vokabeln");
        }
    }
}