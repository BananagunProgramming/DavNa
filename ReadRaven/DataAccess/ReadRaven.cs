using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Enum;
using DataAccess.Indexes;
using DataAccess.Models;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace DataAccess
{
    public class ReadRaven : IDisposable
    {
        private readonly DocumentStore _documentStore;

        public ReadRaven()
        {
            _documentStore = new DocumentStore { Url = "http://digitalocean:8080/databases/analytics" };
            _documentStore.Initialize();

            IndexCreation.CreateIndexes(typeof(EventByEnterpriseName).Assembly, _documentStore);
            IndexCreation.CreateIndexes(typeof(EventByEventType).Assembly, _documentStore);
        }

        public IEnumerable<AnalyticsEvent> GetAllDocuments()
        {
            using (var session = _documentStore.OpenSession())
            {
                var document = session.Query<AnalyticsEvent>().AsEnumerable();
                return document;
            }
        }

        public IEnumerable<AnalyticsEvent> GetDocumentByEnterpriseName(string enterpriseName)
        {
            using (var session = _documentStore.OpenSession())
            {
                var documents = session.Query<AnalyticsEvent, EventByEnterpriseName>().Where(e => e.EnterpriseName == enterpriseName);
                
                return documents.AsEnumerable();
            }
        }

        public IEnumerable<AnalyticsEvent> GetEventsByEventType(AnalyticsEventType eventType)
        {
            using (var session = _documentStore.OpenSession())
            {
                var documents = session.Query<AnalyticsEvent, EventByEventType>().Where(e => e.EventType ==  eventType);

                return documents.AsEnumerable();
            }
        }

        public AnalyticsEvent GetDocumentById(string id)
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Load<AnalyticsEvent>("AnalyticsEvents/" + id);
            }
        }

        public void PushDocumentUpdate(AnalyticsEvent updateDocument, string id)
        {
            using (var session = _documentStore.OpenSession())
            {
                var document = session.Load<AnalyticsEvent>("AnalyticsEvents/" + id);

                document.EnterpriseId = updateDocument.EnterpriseId;
                document.CommunityId = updateDocument.CommunityId;
                document.MemberId = updateDocument.MemberId;
                document.SessionId = updateDocument.SessionId;
                document.MemberRole = updateDocument.MemberRole;
                document.EventName = updateDocument.EventName;
                document.EventUrl = updateDocument.EventUrl;
                document.EventTimeUtc = updateDocument.EventTimeUtc;
                document.EventTimeLocal = updateDocument.EventTimeLocal;
                document.CommunityName = updateDocument.CommunityName;
                document.EnterpriseName = updateDocument.EnterpriseName;
                document.TimeZoneOffset = updateDocument.TimeZoneOffset;
                document.CommunityLanguage = updateDocument.CommunityLanguage;
                document.WurflCapabilities = updateDocument.WurflCapabilities;
                document.UserAgent = updateDocument.UserAgent;
                document.EventType = updateDocument.EventType;
                document.EventParameters = updateDocument.EventParameters;

                session.SaveChanges();
            }
        }

        public IEnumerable<EventTypeCount.ReduceResult> GetAggragateCountByEventType()
        {
            using (var session = _documentStore.OpenSession())
            {
                var result = session.Query<EventTypeCount.ReduceResult, EventTypeCount>();

                return result.AsEnumerable();
            }
        }

        public IEnumerable<CountAllEvents.ReduceResult> CountAllEvents()
        {
            using (var session = _documentStore.OpenSession())
            {
                var result = session.Query<CountAllEvents.ReduceResult, CountAllEvents>();

                return result.AsEnumerable();
            }
        } 

        public void DeleteDocument(string id)
        {
            using (var session = _documentStore.OpenSession())
            {
                var document = session.Load<AnalyticsEvent>("AnalyticsEvents/" + id);
                session.Delete(document);
                session.SaveChanges();
            }
        }

        public void Dispose()
        {
            _documentStore.Dispose();
        }
    }
}
