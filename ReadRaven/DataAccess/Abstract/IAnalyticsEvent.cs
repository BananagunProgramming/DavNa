
using System;
using System.Collections.Generic;
using DataAccess.Enum;
using DataAccess.Models;

namespace DataAccess.Abstract
{
    public interface IAnalyticsEvent : ICommunityEvent
    {
        string EventName { get; set; }
        string EventUrl { get; set; }
        DateTime EventTimeUtc { get; set; }
        AnalyticsEventType EventType { get; set; }
        WurflCapabilities WurflCapabilities { get; set; }
        string UserAgent { get; set; }
        string SessionId { get; set; }
        Dictionary<string, string> EventParameters { get; set; }
    }
}
