<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="List_Web.Loguin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label class="form-label">User</label>
                <asp:TextBox runat="server" ID="txtUser" placeholder="user name" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" placeholder="******" TextMode="Password" ID="txtPassword" CssClass="form-control " />
            </div>
        </div>
        <div class="mb-3">
            <asp:Button Text="Ingresar" runat="server" ID="bntingresar" OnClick="bntingresar_Click" CssClass="btn btn-primary" />
            <a href="Default.aspx">Cancelar</a>
        </div>
    </div>
</asp:Content>
