<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetailPokemon.aspx.cs" Inherits="List_Web.DetailPokemon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
        <Columns>
            <asp:BoundField HeaderText="Name" DataField="Nombre" />
            <asp:BoundField HeaderText="Number" DataField="Numero" />
            <asp:BoundField HeaderText="Type" DataField="Tipo.Descripcion" />
            <asp:CheckBoxField HeaderText="Active" DataField="Activo" />
            <asp:CommandField HeaderText="Action" ShowSelectButton="true" SelectText="✍️" />
        </Columns>

    
   
</asp:Content>
