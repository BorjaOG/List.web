using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using System.Xml.Linq;


namespace List_Web
{
    public partial class FormPokemon : System.Web.UI.Page
    {
        public bool ConfirmDelete { get;set;}

        protected void Page_Load(object sender, EventArgs e)
        {
            txbId.Enabled = false;
            ConfirmDelete = false;
            try
            {
                //configuration inicial.
                if (!IsPostBack)
                {
                    element negocio = new element();
                    List<elemento> list = negocio.listar();

                    ddlType.DataSource = list;
                    ddlType.DataValueField = "ID";
                    ddlType.DataTextField = "Descripcion";
                    ddlType.DataBind();

                    ddlWeak.DataSource = list;
                    ddlWeak.DataValueField = "ID";
                    ddlWeak.DataTextField = "Descripcion";
                    ddlWeak.DataBind();
                }

                //configuration para modificar.
                string ID = Request.QueryString["ID"] != null ? Request.QueryString["ID"].ToString() : "";
                if (ID != "" && !IsPostBack)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    //List<Pokemon> lista = negocio.listar(ID);
                    //Pokemon seleccionado = lista[0];
                    Pokemon seleccionado = (negocio.listar(ID))[0];
                    //save pokemon selected in session
                    Session.Add("pokeSeleccionado", seleccionado);


                    //pre cargar todos los campos..
                    txbId.Text = ID;
                    TxbName.Text = seleccionado.Nombre;
                    txbNumber.Text = seleccionado.Numero.ToString();
                    txbDescription.Text = seleccionado.Descripcion;
                    txbImageUrl.Text = seleccionado.UrlImagen;

                    ddlType.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlWeak.SelectedValue = seleccionado.Debilidad.Id.ToString();
                    txbImageUrl_TextChanged(sender, e);

                    //config actions
                    if (!seleccionado.Activo)
                        btnInactive.Text = "Reactivate";

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
                

                //error screen
            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                nuevo.Numero = int.Parse(txbNumber.Text);
                nuevo.Nombre = TxbName.Text;
                nuevo.Descripcion = txbDescription.Text;
                nuevo.UrlImagen = txbImageUrl.Text;

                nuevo.Tipo = new elemento();
                nuevo.Tipo.Id = int.Parse(ddlType.SelectedValue);
                nuevo.Debilidad = new elemento();
                nuevo.Debilidad.Id = int.Parse(ddlWeak.SelectedValue);

                if(Request.QueryString["ID"] != null)
                {
                    nuevo.Id = int.Parse(txbId.Text);
                    negocio.modificarConSP(nuevo);

                }
                  
                else
                negocio.agregarConSP(nuevo);


                Response.Redirect("ListaPokemon.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }

        protected void txbImageUrl_TextChanged(object sender, EventArgs e)
        {
            ImgPoke.ImageUrl = txbImageUrl.Text;
        }


        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            ConfirmDelete = true;
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkDelete.Checked) 
                { 
                PokemonNegocio negocio = new PokemonNegocio();
                negocio.eliminar(int.Parse(txbId.Text));
                Response.Redirect("ListaPokemon.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void btnInactive_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];

                negocio.eliminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("ListaPokemon.aspx");

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

    }
}