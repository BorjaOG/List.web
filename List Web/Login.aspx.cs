using Dominio;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace List_Web
{
    public partial class Loguin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntingresar_Click(object sender, EventArgs e)
        {

            Trainee trainee = new Trainee();
            TraineeNegocio negocio = new TraineeNegocio();
            try
            {
                trainee.Email = txtemail.Text;
                trainee.Pass = txtPass.Text;
                if (negocio.Login(trainee))
                {
                    Session.Add("trainee", trainee);
                    Response.Redirect("Perfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}
