using System;

namespace VokabelMnemonik.Siren
{
  public class EmbeddedDocument
  {
    public string Class { get; set; }
    public Uri[] Rel { get; set; }
    public Uri HRef { get; set; }
    public string Type { get; set; }
  }
}