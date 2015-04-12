<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Formulario.ascx.cs" Inherits="Murta.OrdemServico.UI.Web.WebForms.OrdemServico.UserControls.Formulario" %>
<div>
    <asp:CheckBox ID="chkFaturado" runat="server" Text="Faturado" />
</div>
<div class="input-box">
    <label>Situação:</label>
    <asp:DropDownList ID="drpSituacao" runat="server">
    </asp:DropDownList>
    <div>
        <asp:RequiredFieldValidator ID="rfvSituacao" runat="server" ErrorMessage="O campo situação é obrigatório" ControlToValidate="drpSituacao" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="input-box">
    <label>Cliente:</label>
    <asp:DropDownList ID="drpCliente" runat="server">
    </asp:DropDownList>
    <div>
        <asp:RequiredFieldValidator ID="rfvCliente" runat="server" ErrorMessage="O campo cliente é obrigatório" ControlToValidate="drpCliente" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="input-box">
    <label>Projeto:</label>
    <asp:DropDownList ID="drpProjeto" runat="server">
    </asp:DropDownList>
    <div>
        <asp:RequiredFieldValidator ID="rfvProjeto" runat="server" ErrorMessage="O campo Projeto é obrigatório" ControlToValidate="drpProjeto" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="input-box">
    <label>Tipo Hora:</label>
    <asp:DropDownList ID="drpTipoHora" runat="server">
    </asp:DropDownList>
    <div>
        <asp:RequiredFieldValidator ID="rfvTipoHora" runat="server" ErrorMessage="O campo Tipo Hora é obrigatório" ControlToValidate="drpTipoHora" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="input-box">
    <label>Data:</label>
    <asp:TextBox ID="txtData" runat="server"></asp:TextBox>
    <div>
        <asp:RequiredFieldValidator ID="rfvData" runat="server" ErrorMessage="O campo Data é obrigatório" ControlToValidate="txtData" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="input-box">
    <label>Início:</label>
    <asp:TextBox ID="txtInicio" runat="server"></asp:TextBox>
    <div>
        <asp:RequiredFieldValidator ID="rfvInicio" runat="server" ErrorMessage="O campo Início é obrigatório" ControlToValidate="txtInicio" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="input-box">
    <label>Fim:</label>
    <asp:TextBox ID="txtFim" runat="server"></asp:TextBox>
    <div>
        <asp:RequiredFieldValidator ID="rfvFim" runat="server" ErrorMessage="O campo Fim é obrigatório" ControlToValidate="txtFim" CssClass="required"></asp:RequiredFieldValidator> 
    </div>
</div>
<div class="input-box">
    <label>Traslado:</label>
    <asp:TextBox ID="txtTraslado" runat="server"></asp:TextBox>
    <div>
        <asp:RequiredFieldValidator ID="rfvTraslado" runat="server" ErrorMessage="O campo Traslado é obrigatório" ControlToValidate="txtTraslado" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="input-box">
    <label>Atividade:</label>
    <asp:TextBox ID="txtAtividade" runat="server" TextMode="MultiLine"></asp:TextBox>
    <div>
        <asp:RequiredFieldValidator ID="rfvAtividade" runat="server" ErrorMessage="O campo Atividade é obrigatório" ControlToValidate="txtAtividade" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>
<div class="input-box">
    <label>Observação:</label>
    <asp:TextBox ID="txtObservacao" runat="server" TextMode="MultiLine"></asp:TextBox>
    <div>
        <asp:RequiredFieldValidator ID="rfvObservacao" runat="server" ErrorMessage="O campo Observação é obrigatório" ControlToValidate="txtObservacao" CssClass="required"></asp:RequiredFieldValidator>
    </div>
</div>
<asp:Button ID="btnEnviar" runat="server" Text="Enviar" />
<asp:Button ID="btnVoltar" runat="server" Text="Voltar" />
