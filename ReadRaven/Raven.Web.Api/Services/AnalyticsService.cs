using System.Collections.Generic;
using DataAccess;
using DataAccess.Enum;
using DataAccess.Indexes;
using DataAccess.Models;
using Raven.Web.Api.Models;
using ServiceStack.ServiceInterface;

namespace Raven.Web.Api.Services
{
    public class AnalyticsService : Service
    {
        private readonly ReadRaven _ravenClient ;

        public AnalyticsService()
        {
            _ravenClient = new ReadRaven();   
        }

        public IEnumerable<AnalyticsEvent> Get(GetEventByEnterpriseNameRequest request)
        {
            return _ravenClient.GetDocumentByEnterpriseName(request.EnterpriseName);
        }

        public AnalyticsEvent Get(GetEventByRavenIdRequest request)
        {
            return _ravenClient.GetDocumentById(request.RavenId);
        }

        public IEnumerable<AnalyticsEvent> Get(GetAllEventsRequest request)
        {
            return _ravenClient.GetAllDocuments();
        }

        public IEnumerable<AnalyticsEvent> Get(GetEventByTypeRequest request)
        {

            AnalyticsEventType aType;

            switch (request.EventType)
            {
                case "AjaxEvent":
                    aType = AnalyticsEventType.AjaxEvent;
                    break;
                case "InPageEvent":
                    aType = AnalyticsEventType.InPageEvent;
                    break;
                default:
                    aType = AnalyticsEventType.PageEvent;
                    break;
            }

            return _ravenClient.GetEventsByEventType(aType);
        }

        public IEnumerable<EventTypeCount.ReduceResult> Get(GetEventsAggregateByTypeRequest request)
        {
            return _ravenClient.GetAggragateCountByEventType();
        }

        public IEnumerable<CountAllEvents.ReduceResult> Get(CountAllEventsRequest request)
        {
            return _ravenClient.CountAllEvents();
        }

        public void Post(DeleteEventRequest request)
        {
            _ravenClient.DeleteDocument(request.RavenId);
        }
    }
}