using Exceptionless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace DemoExceptionless
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ExceptionlessClient.Default.SubmittingEvent += OnExceptionlessSubmittingEvent;
        }

        private void OnExceptionlessSubmittingEvent(object sender, EventSubmittingEventArgs e)
        {

            // Only handle unhandled exceptions.
            if (!e.IsUnhandledError)
                return;

            // Ignore 404s
            if (e.Event.IsNotFound())
            {
                e.Cancel = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(e.Event.ReferenceId) && HttpContext.Current != null)
            {
                e.Event.ReferenceId = Guid.NewGuid().ToString();
                HttpContext.Current.Items.Add("ExceptionId", e.Event.ReferenceId);
            }

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError() as HttpException;

            if (exception.ErrorCode == 404)
            {
                Server.Transfer("~/Errores/404.aspx");
                return;
            }

            Server.Transfer("~/Errores/ErrorGenerico.aspx");
        }

    }
}