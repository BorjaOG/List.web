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

        protected void bntregistro_Click(object sender, EventArgs e)
        {
            try
            {
                Trainee user = new Trainee();
                TraineeNegocio traineeNegocio = new TraineeNegocio();
                EmailService emailService = new EmailService();
                user.Email = txtemail.Text;
                user.Nombre = txtNombre.Text;
                user.Pass = txtPassword.Text;
                int Id = traineeNegocio.insertarNuevo(user);

                emailService.montarCorreo(user.Email, "Bienvenida Trainee", "Hola " + user.Nombre + " te damos la bienvenida a la aplicacion...");
                emailService.enviarEmail();
                Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}