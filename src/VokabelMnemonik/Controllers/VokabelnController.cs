using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SirenDotNet;
using VokabelMnemonik.Domain;
using VokabelMnemonik.Hypermedia;
using VokabelMnemonik.MappingProfiles;
using VokabelMnemonik.Repositories;

namespace VokabelMnemonik.Controllers
{
  [Route("[controller]")]
  public class VokabelnController : Controller
  {
    readonly IMapper _mapper;
    readonly VokabelnRepository _vokabeln;

    public VokabelnController()
    {
      _vokabeln = new VokabelnRepository();
      _mapper = new MapperConfiguration(cfg => { cfg.AddProfile<VokabelHypermediaMapping>(); }).CreateMapper();
    }

    [HttpGet("", Name = "Route_Vokabeln")]
    public IHypermedia<Vokabel> GetAll()
    {
      //HyperMediaFormatter
      return _mapper.Map<IEnumerable<Vokabel>, Hypermedia<Vokabel>>(_vokabeln.GetAll());
    }

    [HttpGet("{key}", Name = "Route_Vokabeln_Entities")]
    // TODO: IHyperMedia zurückgeben
    public Entity GetById(int key)
    {
      var document = new DocumentFactory();
      // Mapping von Vokabel auf IHyperMedia durchführen (MediaTypeFormatter)
      // -> Das ist die Aufgabe des Controllers
      // Tipp: AutoMapper verwenden
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