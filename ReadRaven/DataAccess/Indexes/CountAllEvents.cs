using System.Linq;
using DataAccess.Models;
using Raven.Client.Indexes;

namespace DataAccess.Indexes
{
    public class CountAllEvents : AbstractIndexCreationTask<AnalyticsEvent, CountAllEvents.ReduceResult>
    {
        public class ReduceResult
        {
            public int Count { get; set; }
        }

        public CountAllEvents()
        {
            Map = analyticsEvents => from analyticsEvent in analyticsEvents
                                     select new
                                     {
                                         Count = 1
                                     };

            Reduce = results => from result in results
                                         group result by result.Count
                                             into g
                                             select new
                                             {
                                                 Count = g.Sum(x => x.Count)
                                             };
        }
    }
}
