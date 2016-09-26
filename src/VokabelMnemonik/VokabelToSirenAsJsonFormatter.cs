using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using VokabelMnemonik.Domain;
using VokabelMnemonik.Mapping;

namespace VokabelMnemonik
{
  public class VokabelToSirenAsJsonFormatter : IOutputFormatter
  {
    readonly IAmAMapper<Vokabel> _mapper;

    public VokabelToSirenAsJsonFormatter(IResolveMapper mapperResolver)
    {
      _mapper = mapperResolver.FirstAssignableMapperFor<Vokabel>("application/vnd.siren+json");
    }

    public bool CanWriteResult(OutputFormatterCanWriteContext context)
    {
      if (context?.ContentType == null)
        return false;

      if (!(context.ObjectType == typeof(Vokabel) || IsListOfType(context.ObjectType)))
        return false;

      return _mapper != null;
    }


    public Task WriteAsync(OutputFormatterWriteContext context)
    {
      if (context == null)
        throw new ArgumentNullException(nameof(context));

      var response = context.HttpContext.Response;
      response.ContentType = context.ContentType.ToString();

      object sirenResult;
      if (context.ObjectType == typeof(Vokabel))
      {
        sirenResult = _mapper.MapEntity(context.Object as Vokabel);
      }
      else
      {
        sirenResult = _mapper.MapList(context.Object as IEnumerable<Vokabel>);
      }

      var sirenResultAsJson = JsonConvert.SerializeObject(sirenResult);

      return Task.FromResult(sirenResultAsJson);
    }

    static bool IsListOfType(Type objectType)
    {
      return objectType.IsGenericParameter
             && objectType.IsAssignableFrom(objectType.GenericTypeArguments[0])
             && objectType.GenericTypeArguments[0].GetType() == typeof(Vokabel);
    }
  }
}