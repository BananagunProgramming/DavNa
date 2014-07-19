using ServiceStack.ServiceHost;

namespace Raven.Web.Api.Models
{
    [Route("/GetEnterpriseByName/{EnterpriseName}", "GET")]
    public class GetEventByEnterpriseNameRequest
    {
        public string EnterpriseName { get; set; }
    }

    [Route("/GetEnterpriseById/{RavenId}", "GET")]
    public class GetEventByRavenIdRequest
    {
        public string RavenId { get; set; }
    }

    [Route("/GetAllEvents", "GET")]
    public class GetAllEventsRequest{}

    [Route("/GetEventByType/{EventType}", "GET")]
    public class GetEventByTypeRequest
    {
        public string EventType { get; set; }
    }

    [Route("/DeleteEventById/{RavenId}", "POST")]
    public class DeleteEventRequest
    {
        public string RavenId { get; set; }
    }

    [Route("/GetAggragateCountByEventType", "GET")]
    public class GetEventsAggregateByTypeRequest {}

    [Route("/CountAllEvents","GET")]
    public class CountAllEventsRequest { }
}