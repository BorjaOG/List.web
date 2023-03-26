<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetailPokemon.aspx.cs" Inherits="List_Web.DetailPokemon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <h2>Details</h2>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <hr />

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for=" txbId" class="form-label">ID</label>
                <asp:TextBox runat="server" ID="txbId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for=" txbName" class="form-label">Name</label>
                <asp:TextBox runat="server" ID="TxbName" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for=" txbNumber" class="form-label">Number</label>
                <asp:TextBox runat="server" ID="txbNumber" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlType" class="form-label">Type</label>
                <asp:DropDownList ID="ddlType" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlWeak" class="form-label">Weakness:</label>
                <asp:DropDownList ID="ddlWeak" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for=" txbDescription" class="form-label">Description</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txbDescription" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txbImageUrl" class="form-label">UrlImage</label>
                        <asp:TextBox runat="server" ID="txbImageUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txbImageUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://worldwellnessgroup.org.au/wp-content/uploads/2020/07/placeholder.png"
                        runat="server" ID="ImgPoke" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">             
            </asp:UpdatePanel>

        </div>
    </div>

   
</asp:Content>
