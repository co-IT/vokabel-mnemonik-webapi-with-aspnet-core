using System;
using System.Collections.Generic;

namespace VokabelMnemonik.Hypermedia
{
  public interface IHypermedia<T>
  {
    IEnumerable<OutboundLink> OutboundLinks { get; set; }
    IEnumerable<EmbeddedLink> EmbeddedLinks { get; set; }
    IEnumerable<TemplatedQuery> TemplatesQueries { get; set; }
    IEnumerable<NonIdempotentUpdate> NonIdempotentUpdates { get; set; }
    IEnumerable<IdempotentUpdate<T>> IdempotentUpdates { get; set; }
    IEnumerable<ControlDataForReadRequest> ControlDataForReadRequests { get; set; }
    IEnumerable<ControlDataForUpdateRequest> ControlDataForUpdateRequests { get; set; }
    IEnumerable<ControlDataForInterfaceRequest> ControlDataForInterfaceRequests { get; set; }
    IEnumerable<ControlDataForLinkRequest> ControlDataForLinkRequests { get; set; }

    IEnumerable<IHypermediaPayload<T>> Payloads { get; set; }
  }

  public class ControlDataForInterfaceRequest
  {
  }

  public class ControlDataForLinkRequest
  {

  }

  public class ControlDataForUpdateRequest
  {
    public string Type { get; private set; }
    public string Value { get; private set; }

    public ControlDataForUpdateRequest(string type, string value)
    {
      Type = type;
      Value = value;
    }
  }

  public class ControlDataForReadRequest
  {
    public string Type { get; private set; }

    public ControlDataForReadRequest(string type)
    {
      Type = type;
    }
  }

  public class IdempotentUpdate<T>
  {
    public string Id { get; private set; }
    public string Method { get; private set; }
    public IHypermediaPayload<T> Body { get; private set; }

    public IdempotentUpdate(string id, string method, IHypermediaPayload<T> body)
    {
      Id = id;
      Method = method;
      Body = body;
    }
  }

  public class NonIdempotentUpdate
  {
    public Uri Action { get; private set; }
    public string Value { get; private set; }

    public NonIdempotentUpdate(Uri action, string value)
    {
      Action = action;
      Value = value;
    }
  }

  public class TemplatedQuery
  {
    public string Value { get; private set; }

    public TemplatedQuery(string value)
    {
      Value = value;
    }
  }

  public class EmbeddedLink
  {
    public Uri Src { get; private set; }
    public string Title { get; private set; }

    public EmbeddedLink(Uri src, string title)
    {
      Src = src;
      Title = title;
    }
  }

  public class OutboundLink
  {
    public Uri Href { get; private set; }
    public string Title { get; private set; }

    public OutboundLink(Uri href, string title)
    {
      Href = href;
      Title = title;
    }
  }
}