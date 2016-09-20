using Microsoft.AspNetCore.Mvc;
using SirenDotNet;
using VokabelMnemonik.Hypermedia;
using VokabelMnemonik.Repositories;

namespace VokabelMnemonik.Controllers
{
  [Route("[controller]")]
  public class VokabelnController : Controller
  {
    [HttpGet("", Name = "Route_Vokabeln")]
    public Entity Get()
    {
      var document = new DocumentFactory();
      return document.CreateVokabeln(Url);
    }

    [HttpGet("{key}", Name = "Route_Vokabeln_Entities")]
    public Entity Get(int key)
    {
      var document = new DocumentFactory();
      var vokabel = new VokabelnRepository();
      
      return document.CreateVokabel(Url, vokabel.GetBy(key));
    }

    [HttpPost("anlegen", Name = "Route_Vokabeln_Anlegen")]
    public ActionResult Anlegen([FromBody] VokabelAnlegen vokabel)
    {
      var vokabeln = new VokabelnRepository();
      var created = vokabeln.Create(vokabel);

      return Created(Url.RouteUrl("Route_Vokabeln_Entities", new {key = created.Id}), 
                     null);
    }
  }

  public class VokabelAnlegen
  {
    public string Fremdsprache { get; set; }
    public string Muttersprache { get; set; }
    public string Fremdwort { get; set; }
    public string Übersetzung { get; set; }
    public string Merksatz { get; set; }
  }
}