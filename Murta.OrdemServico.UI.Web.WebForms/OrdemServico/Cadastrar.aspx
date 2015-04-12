<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="Murta.OrdemServico.UI.Web.WebForms.OrdemServico.Cadastrar" %>
<%@ Register src="UserControls/Formulario.ascx" tagname="Formulario" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Formulario ID="Formulario1" runat="server" />
</asp:Content>
