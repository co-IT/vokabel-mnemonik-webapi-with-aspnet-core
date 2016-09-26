using System;
using System.Collections.Generic;

namespace VokabelMnemonik.Siren
{
  public class HypermediaLink
  {
    public IList<string> Rel { get; set; }
    public Uri HRef { get; set; }
  }
}