using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using VokabelMnemonik.Controllers;
using VokabelMnemonik.Domain;
using VokabelMnemonik.Hypermedia;

namespace VokabelMnemonik.MappingProfiles
{
  public class VokabelHypermediaMapping : Profile
  {
    public VokabelHypermediaMapping()
    {
      var routeRegistration = new VokabelnControllerRoutes().Routes();
      var baseUri = new Uri("http://localhost");

      //Id { get; set; }
      //ng Fremdsprache { get; set; }
      //ng Muttersprache { get; set; }
      //ng Fremdwort { get; set; }
      //ng Übersetzung { get; set; }
      //ng Merksatz { get; set; }
      CreateMap<IEnumerable<Vokabel>, Hypermedia<Vokabel>>()
        .ForMember(
          m => m.OutboundLinks,
          mapper =>
          {
            mapper.ResolveUsing(vokabels =>
            {
              var links = new List<OutboundLink>();
              
              var route = routeRegistration.FirstOrDefault(r => r.Name == "Vokabeln_GetAll");
              // var template = new UriTemplate(route.Template).SetParameter("title", entity.id).Resolve();
              var link = new OutboundLink(new UriBuilder(baseUri.Scheme, baseUri.Host, baseUri.Port, route.Template).Uri,
                "self");

              links.Add(link);

              return links;
            });
          }
        );
    }
  }
}