using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;

namespace List_Web
{
    public partial class Lista_Pokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            dgvPokemons.DataSource = negocio.listarconSP();
            dgvPokemons.DataBind();
        }


        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }
        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormPokemon.aspx?ID=" + Id);

        }
    }
}