<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="List_Web.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="col-4">
            <h2>Crea tu perfil de Trainee</h2>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" placeholder="Nombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Email </label>
                <asp:TextBox runat="server" class="form-control" ID="txtemail" placeholder="name@example.com" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" placeholder="******" ID="txtPassword" TextMode="Password" CssClass="form-control " />
            </div>
        </div>
        <div class="mb-3">
            <asp:Button Text="Registrarse" runat="server" ID="bntregistro" OnClick="bntregistro_Click" CssClass=" btn btn-primary" />
            <a href="Default.aspx">Cancelar</a>
        </div>
    </div>
</asp:Content>
