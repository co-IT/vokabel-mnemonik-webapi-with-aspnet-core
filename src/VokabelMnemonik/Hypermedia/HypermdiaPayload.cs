namespace VokabelMnemonik.Hypermedia
{
    public class HypermdiaPayload<T> : IHypermediaPayload<T>
    {
        public string Name { get; set; }
        public T Body { get; set; }
    }
}