<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="WebForms.Site.Cliente.Cadastrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div class="form-group">
        <asp:Label ID="lblCPF" runat="server" Text="CPF:"></asp:Label>
        <asp:TextBox ID="txtCPF" CssClass="form-control" runat="server" MaxLength="11"></asp:TextBox>
    </div>

    <div class="form-group">
    <asp:Label ID="lblNome" runat="server" Text="Nome:"></asp:Label>
    <asp:TextBox ID="txtNome" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
    </div>
    <div class="form-group">
    <asp:Label ID="lblTelefone" runat="server" Text="Telefone:"></asp:Label>
    <asp:TextBox ID="txtTelefone" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
    </div>
    <div class="form-group">
    <asp:Label ID="lblEndereco" runat="server" Text="Endereço:"></asp:Label>
    <asp:TextBox ID="txtEndreco" CssClass="form-control" runat="server" MaxLength="100"></asp:TextBox>
    </div>
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />

</asp:Content>
