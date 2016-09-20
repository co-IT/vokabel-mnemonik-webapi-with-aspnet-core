using System.Collections.Generic;

namespace VokabelMnemonik.Siren
{
  public class BaseDocument
  {
    public IList<string> Class { get; set; }
    public string Title { get; set; }
    public IDictionary<string, object> Properties { get; set; }
    public IList<EmbeddedDocument> Entities { get; set; }
    public IList<HypermediaAction> Actions { get; set; }
    public IList<HypermediaLink> HypermediaLinks { get; set; }
  }
}