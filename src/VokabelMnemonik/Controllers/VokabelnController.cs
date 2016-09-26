using Microsoft.AspNetCore.Mvc;
using SirenDotNet;
using VokabelMnemonik.Hypermedia;
using VokabelMnemonik.Repositories;

namespace VokabelMnemonik.Controllers
{
  [Route("[controller]")]
  public class VokabelnController : Controller
  {
    readonly VokabelnRepository _vokabeln;

    public VokabelnController()
    {
      _vokabeln = new VokabelnRepository();
    }

    [HttpGet("")]
    public object GetAll()
    {
      return _vokabeln.GetAll();
    }

    [HttpGet("{key}")]
    // TODO: IHyperMedia zurückgeben
    public Entity GetById(int key)
    {
      var document = new DocumentFactory();
      var vokabel = new VokabelnRepository();

      return document.CreateVokabel(Url, vokabel.GetBy(key));
    }

    [HttpPost]
    public ActionResult VokabelAnlegen([FromBody] VokabelAnlegen vokabel)
    {
      var vokabeln = new VokabelnRepository();
      var created = vokabeln.Create(vokabel);

      return Created(Url.RouteUrl("Route_Vokabeln_Entities", new {key = created.Id}), null);
    }

    [HttpPost("test_anlegen")]
    public ActionResult TestAnlegen([FromBody] VokabelAnlegen vokabel)
    {
      var vokabeln = new VokabelnRepository();
      var created = vokabeln.Create(vokabel);

      return Created(Url.RouteUrl("Route_Vokabeln_Entities", new {key = created.Id}), null);
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