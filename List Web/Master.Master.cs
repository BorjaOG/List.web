using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using Dominio;
using static System.Net.WebRequestMethods;

namespace List_Web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
            
           imagenAvatar.ImageUrl = "https://www.australianbearings.com.au/uploads/1/1/8/1/118131953/published/new-user_2.png";
            if (!(Page is Loguin || Page is Registro || Page is Default || Page is Error))
            {
                if (!Seguridad.sesionActiva(Session["trainee"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Trainee user = (Trainee)Session["trainee"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imagenAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }



            }

            
        }
       
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void btncontacto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contacto.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}