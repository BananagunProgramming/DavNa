using System;
using System.Web;
using Raven.Web.Api.Services;
using ServiceStack.WebHost.Endpoints;

namespace Raven.Web.Api
{
    public class Global : HttpApplication
    {
        public class AnalyticsAppHost : AppHostBase
        {
            public AnalyticsAppHost() : base("Analytics Events API", typeof(AnalyticsService).Assembly) { }

            public override void Configure(Funq.Container container)
            {
                //Configure application
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {
            new AnalyticsAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}