using System.Collections.Generic;

namespace VokabelMnemonik
{
  public interface IRouteRegistry
  {
    IEnumerable<RouteRegistration> Routes();
  }
}