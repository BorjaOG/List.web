using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Service;
using Dominio;

namespace List_Web
{
    public partial class Lista_Pokemon : System.Web.UI.Page
    {
        public bool AdvancedFilter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Seguridad.esAdmin(Session["trainee"]))
            {
                Session.Add("error", "Se requiere ser Admin para acceder a esta pantalla");
                Response.Redirect("Error.aspx");
            }
            AdvancedFilter = chkAdvanced.Checked;
            if (!IsPostBack)
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("ListaPokemon", negocio.listarconSP());
                dgvPokemons.DataSource = negocio.listarconSP();
                dgvPokemons.DataBind();
            }
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

        protected void Filter_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["ListaPokemon"];
            List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txbfilter.Text.ToUpper()));
            dgvPokemons.DataSource = listaFiltrada;
            dgvPokemons.DataBind();
        }

        protected void chkAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            AdvancedFilter = chkAdvanced.Checked;
            txbfilter.Enabled = !AdvancedFilter;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Number")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}