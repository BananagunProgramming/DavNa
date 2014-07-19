using System;
using System.Collections.Generic;
using DataAccess.Enum;
using DataAccess.Models;

namespace Raven.Web.Api.Models
{
    public class AnalyticsEventsResponse
    {
        public Guid EnterpriseId { get; set; }
        public Guid CommunityId { get; set; }
        public Guid MemberId { get; set; }
        public string SessionId { get; set; }
        public string MemberRole { get; set; }
        public string EventName { get; set; }
        public string EventUrl { get; set; }
        public DateTime EventTimeUtc { get; set; }
        public DateTime EventTimeLocal { get; set; }
        public string CommunityName { get; set; }
        public string EnterpriseName { get; set; }
        public TimeSpan TimeZoneOffset { get; set; }
        public string CommunityLanguage { get; set; }
        public WurflCapabilities WurflCapabilities { get; set; }
        public string UserAgent { get; set; }
        public AnalyticsEventType EventType { get; set; }
        public Dictionary<string, string> EventParameters { get; set; }
    }
}