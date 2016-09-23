namespace VokabelMnemonik.Hypermedia
{
  public interface IHypermediaPayload<T>
  {
    string Name { get; set; }
    T Body { get; set; }
  }

  public class HypermdiaPayload<T> : IHypermediaPayload<T>
  {
    public string Name { get; set; }
    public T Body { get; set; }
  }
}