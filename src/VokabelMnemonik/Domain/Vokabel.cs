namespace VokabelMnemonik.Domain
{
  public class Vokabel
  {
    public int Id { get; set; }
    public string Fremdsprache { get; set; }
    public string Muttersprache { get; set; }
    public string Fremdwort { get; set; }
    public string Übersetzung { get; set; }
    public string Merksatz { get; set; }
  }
}