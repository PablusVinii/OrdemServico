<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Murta.OrdemServico.UI.Web.WebForms.OrdemServico.Index" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="UserControls/FiltrosPesquisa.ascx" TagName="FiltrosPesquisa" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="Cadastrar.aspx">Novo</a>
    <asp:UpdatePanel ID="upPesquisaOS" runat="server">
        <ContentTemplate>
            <uc1:FiltrosPesquisa ID="FiltrosPesquisa1" runat="server" />
            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" />

            <asp:GridView ID="grdOrdensDeServico" runat="server"
                AutoGenerateColumns="False"
                AllowPaging="True"
                OnPageIndexChanging="grdOrdensDeServico_PageIndexChanging"
                EmptyDataText="Não há dados para serem exibidos"
                OnRowDataBound="grdOrdensDeServico_RowDataBound"
                OnSorting="grdOrdensDeServico_Sorting"
                AllowSorting="True" OnRowDeleting="grdOrdensDeServico_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Código" SortExpression="Codigo" />
                    <asp:BoundField DataField="Cliente.Nome" HeaderText="Nome do Cliente" SortExpression="Cliente.Nome" />
                    <asp:BoundField DataField="Funcionario.Nome" HeaderText="Funcionário" SortExpression="Funcionario.Nome" />
                    <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
                    <asp:BoundField DataField="Inicio" HeaderText="Início" SortExpression="Inicio" />
                    <asp:BoundField DataField="Fim" HeaderText="Fim" SortExpression="Fim" />
                    <asp:BoundField DataField="Traslado" HeaderText="Traslado" SortExpression="Traslado" />
                    <asp:BoundField DataField="Status.Descricao" HeaderText="Status" SortExpression="Status.Descricao" />
                    <asp:HyperLinkField HeaderText="..." Text="Detalhes" DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="~/OrdemServico/Detalhes.aspx?id={0}" />
                    <asp:HyperLinkField HeaderText="..." Text="Editar" DataNavigateUrlFields="Codigo" DataNavigateUrlFormatString="~/OrdemServico/Editar.aspx?id={0}" />
                    <asp:CommandField ShowDeleteButton="True" DeleteText="Excluir" HeaderText="..." />
                </Columns>
                <PagerSettings Position="Bottom" Mode="NextPreviousFirstLast"
                    PreviousPageText="Anterior"
                    NextPageText="Próximo"
                    FirstPageText="Primeira"
                    LastPageText="Última" />
            </asp:GridView>
            <asp:Panel ID="pnlExcluirOS" runat="server" CssClass="modal" Visible="false">
                <h2>Tem certeza que deseja excluir a Ordem de Serviço nº xxx?</h2>
                <asp:Button ID="btnExcluirOS" runat="server" Text="Excluir" OnClick="btnExcluirOS_Click" />
                <asp:Button ID="btnCancelarExclusao" runat="server" Text="Cancelar" OnClick="btnCancelarExclusao_Click" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
