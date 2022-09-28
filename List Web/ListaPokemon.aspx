<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="List_Web.Lista_Pokemon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1> LISTA POKEMON</h1>
    <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="ID" 
        CssClass="table" AutoGenerateColumns="false" 
        OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
        OnPageIndexChanging="dgvPokemons_PageIndexChanging"
        AllowPaging="True" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Name" DataField="Nombre" />
            <asp:BoundField HeaderText="Number" DataField="Numero" />
            <asp:BoundField HeaderText="Type" DataField="Tipo.Descripcion" />
            <asp:CheckBoxField HeaderText="Active" DataField="Activo" />
            <asp:CommandField HeaderText="Action" ShowSelectButton="true" SelectText="✍️" />
        </Columns>

    </asp:GridView>  
    <a href="FormPokemon.aspx" class="btn btn-primary">Add</a>
    
</asp:Content>
