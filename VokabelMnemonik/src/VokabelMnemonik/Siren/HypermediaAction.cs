using System;
using System.Collections.Generic;

namespace VokabelMnemonik.Siren
{
  public class HypermediaAction
  {
    public string Name { get; set; }
    public string Title { get; set; }
    public string Method { get; set; }
    public Uri HRef { get; set; }
    public IList<HypermediaActionField> Fields { get; set; }
  }
}