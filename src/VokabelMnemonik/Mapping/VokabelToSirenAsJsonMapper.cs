using System.Collections.Generic;
using VokabelMnemonik.Domain;

namespace VokabelMnemonik.Mapping
{
  public class VokabelToSirenAsJsonMapper : IAmAMapper<Vokabel>
  {
    readonly IRouteRegistry _routeRegistry;

    public VokabelToSirenAsJsonMapper(IRouteRegistry routeRegistry)
    {
      _routeRegistry = routeRegistry;
    }

    public object MapList(IEnumerable<Vokabel> entities)
    {
      return null;
    }

    public object MapEntity(Vokabel entity)
    {
      return null;
      //var _urls = _urlHelperFactory.GetUrlHelper()

      //var result = new Entity
      //{
      //  Title = "Vokabeln",
      //  Links = new[] {new Link(_urls.RouteUrl("Route_Vokabeln"), "self")},
      //  Actions = new[]
      //  {
      //    new Action("Anlegen", _urls.RouteUrl("Route_Vokabeln_Anlegen"))
      //    {
      //      Method = HttpVerbs.POST,
      //      Fields = new[]
      //      {
      //        new Field("Fremdsprache", FieldTypes.Text),
      //        new Field("Muttersprache", FieldTypes.Text),
      //        new Field("Fremdwort", FieldTypes.Text),
      //        new Field("Übersetzung", FieldTypes.Text),
      //        new Field("Merksatz", FieldTypes.Text)
      //      }
      //    }
      //  }
      //};
      //return result;
    }
  }
}