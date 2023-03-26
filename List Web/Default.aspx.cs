using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace List_Web
{
    public partial class Default : System.Web.UI.Page
    {

        public List<Pokemon> PokemonList { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            PokemonList = negocio.listarConSP();

            

            if (!IsPostBack)
            {
                repRepetidor.DataSource = PokemonList;
                repRepetidor.DataBind();

            }
           

        }

        protected void btnBtn_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}