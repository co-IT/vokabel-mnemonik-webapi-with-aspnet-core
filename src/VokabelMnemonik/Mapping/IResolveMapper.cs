namespace VokabelMnemonik.Mapping
{
  public interface IResolveMapper
  {
    IAmAMapper<T> FirstAssignableMapperFor<T>(string request) where T : class, new();
  }
}