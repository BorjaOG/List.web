<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="List_Web.Loguin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6">
        <div class="mb-3">
            <label class="form-label">User</label>
            <asp:TextBox runat="server" id="txtUser" placeholder="user name" CssClass="form-control"/>
        </div>
        <div class="mb-3">
            <label class="form-label">Password</label>
            <asp:TextBox runat="server" placeholder="******" id="txtPassword" CssClass="form-control "/>
        </div>
        <asp:Button Text="Ingresar" runat="server" ID="bntingresar" OnClick="bntingresar_Click" CssClass="btn-primary" />
    </div>
</asp:Content>
