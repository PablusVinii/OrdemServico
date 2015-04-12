<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FiltrosPesquisa.ascx.cs" Inherits="Murta.OrdemServico.UI.Web.WebForms.OrdemServico.UserControls.FiltrosPesquisa" %>

<div class="input-box-two-cl">
    <asp:Label ID="lblDataDe" runat="server" Text="Data De:"></asp:Label>
    <asp:TextBox ID="txtDataDe" runat="server"></asp:TextBox>
</div>
<div class="input-box-two-cl">
    <asp:Label ID="lblDataAte" runat="server" Text="Data Até:"></asp:Label>
    <asp:TextBox ID="txtDataAte" runat="server"></asp:TextBox>
</div>
<div class="input-box">
    <asp:Label ID="lblCliente" runat="server" Text="Clientes:"></asp:Label>
    <asp:DropDownList ID="drpClientes" runat="server"></asp:DropDownList>
</div>
<div class="input-box">
    <asp:Label ID="lblFuncionaris" runat="server" Text="Funcionarios:"></asp:Label>
    <asp:DropDownList ID="drpFuncionarios" runat="server"></asp:DropDownList>
</div>