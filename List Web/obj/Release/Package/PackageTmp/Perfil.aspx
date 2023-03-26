<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="List_Web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h1>Welcome to your profile</h1>
    <h2>Add or modify your profile</h2>
    <hr />
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtemail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Name</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtnombre" />
            </div>
            <div class="mb-3">
                <label class="form-label">Surname</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtapellido" />
            </div>
            <div class="mb-3">
                <label class="form-label">Date of birth</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtnacimiento" TextMode="Date" />
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Profile image</label>
                <input type="file" id="txtimagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imagenNuevoPerfil" ImageUrl="https://i0.wp.com/blogs.princeton.edu/mathclub/wp-content/plugins/post-grid/assets/frontend/images/placeholder.png?w=640&ssl=1"
                runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>

    <div class="col-md-4">
        <div class="mb-3">
            <asp:Button ID="btnguardar" OnClick="btnguardar_Click" runat="server" Text="Save" CssClass="btn btn-primary" />
            <a href="/">Back</a>
        </div>
    </div>
</asp:Content>
