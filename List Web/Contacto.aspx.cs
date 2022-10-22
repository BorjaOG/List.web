using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;

namespace List_Web
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            EmailService emailservice = new EmailService();
            emailservice.montarCorreo(txtemail.Text, txtasunto.Text, txtmensaje.Text);
            try
            {
                emailservice.enviarEmail();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}