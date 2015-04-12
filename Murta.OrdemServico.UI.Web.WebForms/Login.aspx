<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Murta.OrdemServico.UI.Web.WebForms.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entrar - Ordens de Serviço</title>
    <link type="text/css" href="Content/Site.css" media="all" rel="stylesheet" />
</head>
<body style="background:#cacaca">
    <div id="login-box">
        <form id="form1" runat="server">
            <div>
                <div id="login-label">Por favor identifique-se</div>
                <div class="input-box">
                    <label>Login</label>
                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ErrorMessage="O campo login é obrigatório" ControlToValidate="txtLogin" CssClass="required"></asp:RequiredFieldValidator>
                </div>
                <div class="input-box">
                    <label>Senha</label>
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSenha" runat="server" ErrorMessage="O campo senha é obrigatório" ControlToValidate="txtSenha" CssClass="required"></asp:RequiredFieldValidator>
                </div>
                <div class="checkbox-login">                    
                    <asp:CheckBox ID="chbLembrarSenha" Text="Lembrar Senha" runat="server" />
                </div>
                <div class="input-box">
                    <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="button button-blue" OnClick="btnEntrar_Click" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
