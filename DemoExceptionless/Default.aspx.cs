using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Exceptionless;

namespace DemoExceptionless
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHandledException_Click(object sender, EventArgs e)
        {

            try
            {
                var con = new SqlConnection("DataSource=ServidorFalso");
                con.Open(); // aquí tiene que dar error.
            }
            catch (Exception ex)
            {
                var id = Guid.NewGuid().ToString();

                ex.ToExceptionless()
                    .SetReferenceId(id)
                    .SetUserIdentity("mike", "Miguel Román") // por defecto exceptionless agregará la información de User.Identity.Name si está logueado
                    .AddTags("modulo-x")
                    .AddObject(new { Id = 1, Titulo = "Información Adicional" })
                    .Submit();

                lblMensaje.Text = string.Format("Ocurrió un error al ejecutar la operación solicitada (Referencia: {0})", id);
            }

        }

        protected void btnUnhandledException_Click(object sender, EventArgs e)
        {
            var con = new SqlConnection("DataSource=ServidorFalso");
            con.Open(); // aquí tiene que dar error.
        }
    }
}