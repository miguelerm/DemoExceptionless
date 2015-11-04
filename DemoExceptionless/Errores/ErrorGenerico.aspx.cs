using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoExceptionless.Errores
{
    public partial class ErrorGenerico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var error = Server.GetLastError();

            if (error != null)
            {
                // Error en un inicio siempre será HttpUnhandledException
                if (error.InnerException != null)
                {
                    error = error.InnerException;
                }

                string exceptionId = Context.Items.Contains("ExceptionId") ? Context.Items["ExceptionId"] as string: "";
                lblMensaje.Text = string.Format("Error {0} de tipo {1} al consultar la pagina {2}", exceptionId, error.GetType(), Request.RawUrl);
            }
        }
    }
}