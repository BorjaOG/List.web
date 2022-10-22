<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="List_Web.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <label class="form-label">Email </label>
                <asp:TextBox runat="server" class="form-control" ID="txtemail" placeholder="name@example.com" />
            </div>
            <div class="mb-3">
                <label class="form-label">Asunto</label>
                <asp:TextBox runat="server" class="form-control" ID="txtasunto" placeholder="" />
            </div>
            <div class="mb-3">
                <label class="form-label">Mensaje</label>
                <asp:TextBox TextMode="MultiLine" runat="server" class="form-control" id="txtmensaje" rows="3"/> 
            </div>
            <asp:Button class="btn-primary" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
        </div>
        <div class="col"></div>
    </div>

</asp:Content>
