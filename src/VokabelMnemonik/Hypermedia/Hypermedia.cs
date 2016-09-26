using System.Collections.Generic;

namespace VokabelMnemonik.Hypermedia
{
    public class Hypermedia<T> : IHypermedia<T>
    {
        public IEnumerable<OutboundLink> OutboundLinks { get; set; }
        public IEnumerable<EmbeddedLink> EmbeddedLinks { get; set; }
        public IEnumerable<TemplatedQuery> TemplatesQueries { get; set; }
        public IEnumerable<NonIdempotentUpdate> NonIdempotentUpdates { get; set; }
        public IEnumerable<IdempotentUpdate<T>> IdempotentUpdates { get; set; }
        public IEnumerable<ControlDataForReadRequest> ControlDataForReadRequests { get; set; }
        public IEnumerable<ControlDataForUpdateRequest> ControlDataForUpdateRequests { get; set; }
        public IEnumerable<ControlDataForInterfaceRequest> ControlDataForInterfaceRequests { get; set; }
        public IEnumerable<ControlDataForLinkRequest> ControlDataForLinkRequests { get; set; }
        public IEnumerable<IHypermediaPayload<T>> Payloads { get; set; }
    }
}