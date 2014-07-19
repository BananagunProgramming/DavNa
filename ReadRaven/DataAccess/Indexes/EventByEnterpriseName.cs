using System.Linq;
using DataAccess.Models;
using Raven.Client.Indexes;

namespace DataAccess.Indexes
{
    public class EventByEnterpriseName : AbstractIndexCreationTask<AnalyticsEvent>
    {

        public EventByEnterpriseName()
        {
            Map = analyticsEvents => from analyticsEvent in analyticsEvents
                select new {analyticsEvent.EnterpriseName};
        }
    }
}
