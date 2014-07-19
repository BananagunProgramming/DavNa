using System.Linq;
using DataAccess.Models;
using Raven.Client.Indexes;

namespace DataAccess.Indexes
{
    class EventByEventType : AbstractIndexCreationTask<AnalyticsEvent>
    {
        public EventByEventType()
        {
            Map = analyticsEvents => from analyticsEvent in analyticsEvents
                                     select new { analyticsEvent.EventType };
        }
    }
}
