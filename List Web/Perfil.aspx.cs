using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Service;

namespace List_Web
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sesionActiva(Session["trainee"]))
                    {
                        Trainee user = (Trainee)Session["trainee"];
                        txtemail.Text = user.Email;
                        txtemail.ReadOnly = true;
                        txtnombre.Text = user.Nombre;
                        txtapellido.Text = user.Apellido;
                        txtnacimiento.Text = user.FechaNacimiento.ToString("yyyy-MM-dd");
                        if(!string.IsNullOrEmpty(user.ImagenPerfil))
                            imagenNuevoPerfil.ImageUrl = "~/images/" + user.ImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
            
         
            

        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeNegocio negocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["trainee"];
                if (txtimagen.PostedFile.FileName != "")
                {

                    string ruta = Server.MapPath("./images/");
                    txtimagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                user.Nombre = txtnombre.Text;
                user.Apellido = txtapellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtnacimiento.Text);

                negocio.actualizar(user);

                Image img = (Image)Master.FindControl("imagenAvatar");
                img.ImageUrl = "~/images/" + user.ImagenPerfil;


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}