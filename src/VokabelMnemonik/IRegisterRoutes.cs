using System.Collections.Generic;

namespace VokabelMnemonik
{
  public interface IRegisterRoutes
  {
    IEnumerable<RouteRegistration> Routes();
  }
}