using System.Linq;
using DataAccess.Models;
using Raven.Client.Indexes;
using Raven.Client.Linq;

namespace DataAccess.Indexes
{
    public class EventTypeCount : AbstractIndexCreationTask<AnalyticsEvent, EventTypeCount.ReduceResult>
    {
        public class ReduceResult
        {
            public string EventType { get; set; }
            public int Count { get; set; }
        }

        public EventTypeCount()
        {
            Map = analyticsEvents => from analyticsEvent in analyticsEvents
                                     select new
                                            {
                                                analyticsEvent.EventType,
                                                Count = 1
                                            };

            Reduce = results => from result in results
                group result by result.EventType
                into g
                select new
                       {
                           EventType = g.Key,
                           Count = g.Sum(x => x.Count)
                       };
        }
    }
}
