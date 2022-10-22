<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="List_Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />

    <h1>Pokedex</h1>
    <p>todo lo que necesitas saber sobre pokemon</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%-- <% 

            foreach (Dominio.Pokemon poke in PokemonList)
            {
        %>



        <div class="col">
            <div class="card">
                <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: poke.Nombre %></h5>
                    <p class="card-text"><%:poke.Descripcion %></p>
                    <a href="DetailPokemon.aspx?Id=<%:poke.Id %>">Ver detalle</a>
                </div>
            </div>
        </div>
        <%  } %> --%>


        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                             <a CssClass="btn btn-primary" href="DetailPokemon.aspx?Id=<%#Eval("Id") %>">Ver detalle</a>
                           
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
