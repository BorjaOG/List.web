<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ListaPokemon.aspx.cs" Inherits="List_Web.Lista_Pokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>LISTA POKEMON</h1>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Filter by Name" runat="server" />
                <asp:TextBox runat="server" ID="txbfilter" CssClass="form-control" AutoPostBack="true" OnTextChanged="Filter_TextChanged" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction:column; justify-content: flex-end">
            <div class="mb-3">
                <asp:CheckBox Text="Avanced Filter" 
                    CssClass="" ID="chkAdvanced" runat="server" 
                    AutoPostBack="true"
                    OnCheckedChanged="chkAdvanced_CheckedChanged" />
            </div>
        </div>
        <%if (chkAdvanced.Checked)
            { %>
        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Campo" runat="server" />
                    <asp:DropDownList runat="server" AutoPostBack="true" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                        <asp:ListItem Text="Name" />
                        <asp:ListItem Text="Type" />
                        <asp:ListItem Text="Number" />
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Criterial" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Filter" runat="server" />
                    <asp:TextBox runat="server" ID="txbAdvancedFilter" CssClass="form-control"/>
                </div>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Status" runat="server" />
                    <asp:DropDownList runat="server" ID="ddlStatus" CssClass="form-control">
                        <asp:ListItem Text="all" />
                        <asp:ListItem Text="Active" />
                        <asp:ListItem Text="Inactive" />
                    </asp:DropDownList>
                    </div>
                </div>
            </div>
         <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Search" runat="server" CssClass="btn btn-primary" ID="btnSearch" OnClick="btnSearch_Click" />
                    </div>
                </div>
             </div>
        <%} %>
        </div>

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
