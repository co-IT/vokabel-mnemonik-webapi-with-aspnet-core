using System;
using Autofac;

namespace VokabelMnemonik.Mapping
{
  internal class MapperResolver : IResolveMapper, IDisposable
  {
    readonly ILifetimeScope _scope;

    public MapperResolver(ILifetimeScope scope)
    {
      _scope = scope.BeginLifetimeScope();
    }

    public void Dispose()
    {
      _scope.Dispose();
    }

    public IAmAMapper<T> FirstAssignableMapperFor<T>(string contentType) where T : class, new()
    {
      var foundMapper = _scope.Resolve<IAmAMapper<T>>();
      return foundMapper;
      //var contentType = request.ContentType;
      //var contentTypeWithoutNamespace = contentType.Split('/').Last();
      //var hypermediaFormat = contentTypeWithoutNamespace.Split('+').First().Split('.').Last();
      //var dataFormat = contentTypeWithoutNamespace.Split('+').Last();
      //var entityName = typeof(T).Name;
      //var mapperName = (entityName + "to" + hypermediaFormat + "as" + dataFormat + "mapper").ToLower();

      //throw new NotImplementedException();
    }
  }
}