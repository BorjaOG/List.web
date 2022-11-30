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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnregistro_Click1(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                EmailService emailService = new EmailService();

                user.Nombre = txtNombre.Text;               
                user.Email = txtmail.Text;
                user.Pass = txtPassword.Text;
                

                user.Id = traineeNegocio.insertarNuevo(user);
                Session.Add("trainee", user);

                emailService.montarCorreo(user.Email, "Bienvenido Trainee", "Hola " + user.Nombre + " te damos la bienvenida a la aplicacion...");
                emailService.enviarEmail();
                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
            try
            {
                TraineeNegocio negocio = new TraineeNegocio();
                Trainee user = (Trainee)Session["trainee"];
               

                

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