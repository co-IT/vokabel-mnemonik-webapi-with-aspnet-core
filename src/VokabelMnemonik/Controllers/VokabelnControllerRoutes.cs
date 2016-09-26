using System.Collections.Generic;

namespace VokabelMnemonik.Controllers
{
    public class VokabelnControllerRoutes : IRegisterRoutes
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
}