using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace List_Web
{
    public partial class Pagina2LoguinAdmin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.Admin))
            {
                Session.Add("error", "no tienes permiso para ingresar como admin.");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}