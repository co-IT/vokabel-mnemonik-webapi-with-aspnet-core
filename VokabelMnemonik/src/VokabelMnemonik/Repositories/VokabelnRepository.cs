using System.Collections.Generic;
using System.Linq;
using VokabelMnemonik.Controllers;
using VokabelMnemonik.Domain;

namespace VokabelMnemonik.Repositories
{
  public class VokabelnRepository
  {
    static readonly IList<Vokabel> Vokabeln = new List<Vokabel>
    {
      new Vokabel
      {
        Id = 1,
        Fremdsprache = "Latein",
        Muttersprache = "Deutsch",
        Fremdwort = "cubare",
        Übersetzung = "liegen",
        Merksatz = "Die Kuh liegt auf einer Bare"
      }
    };

    public Vokabel GetBy(int key)
    {
      return Vokabeln.SingleOrDefault(v => v.Id == key);
    }

    public Vokabel Create(VokabelAnlegen vokabel)
    {
      var vok = new Vokabel
      {
        Id = Vokabeln.Max(v => v.Id) + 1,
        Fremdsprache = vokabel.Fremdsprache,
        Muttersprache = vokabel.Muttersprache,
        Fremdwort = vokabel.Fremdwort,
        Übersetzung = vokabel.Übersetzung,
        Merksatz = vokabel.Merksatz
      };

      Vokabeln.Add(vok);
      return vok;
    }
  }
}