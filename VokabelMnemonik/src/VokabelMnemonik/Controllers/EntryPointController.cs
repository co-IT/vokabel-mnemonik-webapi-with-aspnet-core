using Microsoft.AspNetCore.Mvc;
using SirenDotNet;
using VokabelMnemonik.Hypermedia;

namespace VokabelMnemonik.Controllers
{
  [Route("[controller]")]
  public class EntryPointController : Controller
  {
    [HttpGet("", Name = "Root_EntryPoint")]
    public Entity Get()
    {
      var document = new DocumentFactory();
      return document.CreateEntryPoint(Url);
    }
  }
}