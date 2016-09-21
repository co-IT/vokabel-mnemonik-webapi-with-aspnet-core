using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SirenDotNet;
using VokabelMnemonik.Domain;

namespace VokabelMnemonik.Hypermedia
{
  public class DocumentFactory
  {
    public Entity CreateEntryPoint(IUrlHelper urls)
    {
      var entryPointRoot = new Link(urls.RouteUrl("Route_EntryPoint"), "self") { Title = "Entry Point" };
      var entryPointVokabeln = new Link(urls.RouteUrl("Route_Vokabeln"), "vokabeln") { Title = "Vokabeln" };
      return new Entity
      {
        Title = "Entry Point",
        Links = new[]
        {
          entryPointRoot,
          entryPointVokabeln
        }
      };
    }

    public Entity CreateVokabeln(IUrlHelper urls)
    {
      return new Entity
      {
        Title = "Vokabeln",
        Links = new[] {new Link(urls.RouteUrl("Route_Vokabeln"), "self")},
        Actions = new[]
        {
          new Action("Anlegen", urls.RouteUrl("Route_Vokabeln_Anlegen"))
          {
            Method = HttpVerbs.POST,
            Fields = new[]
            {
              new Field("Fremdsprache", FieldTypes.Text),
              new Field("Muttersprache", FieldTypes.Text),
              new Field("Fremdwort", FieldTypes.Text),
              new Field("Übersetzung", FieldTypes.Text),
              new Field("Merksatz", FieldTypes.Text),
            }
          }
        }
      };
    }

    public Entity CreateVokabel(IUrlHelper urls, Vokabel vokabel)
    {
      dynamic foobar = new JObject();
      foobar.Muttersprache = vokabel.Muttersprache;
      foobar.Fremdsprache = vokabel.Fremdsprache;
      foobar.Fremdwort = vokabel.Fremdwort;
      foobar.Übersetzung = vokabel.Übersetzung;
      foobar.Merksatz = vokabel.Merksatz;

      return new Entity
      {
        Class = new[] {"Vokabel"},
        Links = new[]
        {
          new Link(urls.RouteUrl("Route_Vokabeln_Entities",
            new {key = vokabel.Id}), "self")
        },
        Properties = foobar
      };
    }
  }
}