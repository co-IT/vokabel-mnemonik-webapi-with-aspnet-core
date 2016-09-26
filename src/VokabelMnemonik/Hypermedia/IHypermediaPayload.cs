namespace VokabelMnemonik.Hypermedia
{
    public interface IHypermediaPayload<T>
    {
        string Name { get; set; }
        T Body { get; set; }
    }
}