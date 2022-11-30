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


    public partial class DetailPokemon : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
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


                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);


                //error screen
            }
        }
        protected void txbImageUrl_TextChanged(object sender, EventArgs e)
        {
            ImgPoke.ImageUrl = txbImageUrl.Text;
        }




    }
    }
