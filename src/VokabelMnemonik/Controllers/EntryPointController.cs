using Microsoft.AspNetCore.Mvc;
using SirenDotNet;
using VokabelMnemonik.Hypermedia;

namespace VokabelMnemonik.Controllers
{
  /*
    Entry point = Basisadresse Bsp.: api.vokabel-mnemonik.de/
    - Dokumentation abrufen
    - Hypermedia Dokument abrufen

    Oder docs.api.vokabel-mnemonik.de -> Dokumentation
              api.vokabel-mnemonik.de -> Immer Siren

    Kommt darauf an wie man es modelliert.
   */
  [Route("")]
  public class EntryPointController : Controller
  {
    [HttpGet("", Name = "Route_EntryPoint")]
    // Mit Entity wird Rückgabetyp bereits festgelegt
    // Es sollte Hypermedia-Typ zurückgegeben werden, damit das Formatieren möglich wird.
    public Entity Get()
    {
      // Controller ist zuständig, welche Repräsentation versendet wird.
      var document = new DocumentFactory();

      // Mitgeben welcher Mime-Type generiert werden soll.
      // Media-Type-Formatter: https://damienbod.com/2015/06/03/asp-net-5-mvc-6-custom-protobuf-formatters/
      return document.CreateEntryPoint(Url);
    }
  }
}