using System;
using System.Linq;
using DataAccess;
using DataAccess.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReadRaveTeset
{
    [TestClass]
    public class UnitTest1
    {
    
        [TestMethod]
        public void GetAllDocuments()
        {
            var ravenClient = new ReadRaven();

            var results = ravenClient.GetAllDocuments();
            Console.WriteLine(results.Count());
        }

        [TestMethod]
        public void AlterDocument()
        {
            var documentId = "1";
            var ravenClient = new ReadRaven();
            var result = ravenClient.GetDocumentById(documentId);

            result.EnterpriseName = "traf";
            result.EventParameters["quickPollCount"] = "10";

            ravenClient.PushDocumentUpdate(result, documentId);

        }

        //[TestMethod]
        //public void DeleteDocument()
        //{
        //    var ravenClient = new ReadRaven();
        //    ravenClient.DeleteDocument("3");
        //}

        [TestMethod]
        public void GetByEnterpriseByName()
        {
            var ravenClient = new ReadRaven();
            var result = ravenClient.GetDocumentByEnterpriseName("StarshipEnterprise");
            Console.WriteLine("Document count: " + result.Count());
        }

        [TestMethod]
        public void GetDocumentById()
        {
            var ravenClient = new ReadRaven();
            var result = ravenClient.GetDocumentById("1");
            Console.WriteLine(result.EnterpriseName);
        }

        [TestMethod]
        public void GetEventsByEventType()
        {
            var ravenClient = new ReadRaven();

            var eventType = "PageEvent";

            AnalyticsEventType aType;

            switch (eventType)
            {
                case "PageEvent":
                    aType = AnalyticsEventType.PageEvent;
                    break;
                default:
                    aType = AnalyticsEventType.AjaxEvent;
                    break;
            }
            var result = ravenClient.GetEventsByEventType(aType);
        }

        [TestMethod]
        public void TestIndexWithGroup()
        {
            var ravenClient = new ReadRaven();
            var result = ravenClient.GetAggragateCountByEventType();
            foreach (var item in result)
            {
                Console.WriteLine(item.EventType + ":" + item.Count);
            }
        }

        [TestMethod]
        public void TotalCountOfEvents()
        {
            var ravenClient = new ReadRaven();
            var result = ravenClient.CountAllEvents();
            foreach (var item in result)
            {
                Console.WriteLine(item.Count);
            }
        }
    }
}
