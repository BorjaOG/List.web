<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MenuLogin.aspx.cs" Inherits="List_Web.Pagina2LoguinAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-12">
            <h3>Log in successfull</h3>
            <hr />
            </div>
            <div class="col-4">
                <asp:Button Text="pag1" id="btnpag1" runat="server" OnClick="btnpag1_Click" CssClass="btn-primary" />
            </div>
            <div class="col-4">
                <%if (Session["usuario"] != null && ((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.Admin)
                    {  %>
                <asp:Button Text="pag2" id="btnpag2" runat="server" OnClick="btnpag2_Click" CssClass="btn-primary" />
                <p>Only Admins can acces.</p>
                <% }%>
            </div>
        </div>
</asp:Content>
