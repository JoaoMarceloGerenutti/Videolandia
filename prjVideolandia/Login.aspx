<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="prjVideolandia.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Videolândia - Login</title>
    <link rel="stylesheet" href="Login.css" />
    <link rel="shortcut icon" href="Imagens/favicon.ico" />
</head>
<body>
    <header class="header">
        <a href="Default.aspx"><img src="Imagens/Videolândia.png" alt="Netflix" draggable="false" class="logo" /></a>
    </header>

    <form id="frmLogin" runat="server">
        <div class="gradient"></div>
        <div class="login-wrap">
            <div class="login-html">
                <input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab" />Entrar</label>
                <input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab" />Inscrever-se</label>
                <div class="login-form">
                    <div class="sign-in-htm">
                        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" DestinationPageUrl="~/Videolandia.aspx" Width="385px">
                            <LayoutTemplate>
                                <div class="group">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" for="user" CssClass="label">E-mail</asp:Label>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Preencha o Campo de E-mail!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="UserName" ErrorMessage="Informe um E-mail Válido!" ForeColor="#E50914" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Bold="True" Font-Size="Large" ValidationGroup="Login1">*</asp:RegularExpressionValidator>
                                    <asp:TextBox ID="UserName" runat="server" type="text" CssClass="input"></asp:TextBox>
                                </div>
                                <div class="group">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" CssClass="label">Senha</asp:Label>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="A Senha é Obrigatória!" ToolTip="A senha é obrigatória." ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" type="text" CssClass="input"></asp:TextBox>
                                </div>
                                <div class="group">
                                    <input id="check" type="checkbox" class="check" checked>
                                    <label for="check"><span class="icon"></span> Lembrar Senha </label>
                                </div>
                                <div class="group">
                                    <asp:ValidationSummary ID="vsEntrar" runat="server" ForeColor="#E50914" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Login1" />
                                </div>
                                <div class="group">
                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Entrar" ValidationGroup="Login1" CssClass="button"/>
                                </div>
                            </LayoutTemplate>
                        </asp:Login>

                        <div class="hr"></div>
                        <div class="foot-lnk">
                            <a href="#forgot">Esqueceu sua senha?</a>
                        </div>
                    </div>
                    <div class="sign-up-htm">
                        <div class="group">
                            <label for="pass" class="label">E-mail</label>
                            <asp:RequiredFieldValidator ID="rfvCriarEmail" runat="server" ControlToValidate="txbCriarEmail" ErrorMessage="O E-mail é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="register">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revCriarEmail" runat="server" ControlToValidate="txbCriarEmail" ErrorMessage="E-mail Inválido!" ForeColor="#E50914" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Bold="True" Font-Size="Large" ValidationGroup="register">*</asp:RegularExpressionValidator>
                            <asp:TextBox ID="txbCriarEmail" runat="server" type="text" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <label for="user" class="label">Nome</label>
                            <asp:RequiredFieldValidator ID="rfvNome" runat="server" ControlToValidate="txbNome" ErrorMessage="O Nome é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="register">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txbNome" runat="server" type="text" class="input"></asp:TextBox>
                        </div>
                        <div class="group">
                            <label for="pass" class="label">Senha</label>
                            <asp:RequiredFieldValidator ID="rfvCriarSenha" runat="server" ControlToValidate="txbCriarSenha" ErrorMessage="A Senha é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="register">*</asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvSenha" runat="server" ControlToCompare="txbCriarSenha" ControlToValidate="txbRepetirSenha" ErrorMessage="As Senhas não coincidem!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="register">*</asp:CompareValidator>
                            <asp:TextBox ID="txbCriarSenha" runat="server" type="password" class="input" data-type="password"></asp:TextBox>
                        </div>
                        <div class="group">
                            <label for="pass" class="label">Repetir a senha</label>
                            <asp:RequiredFieldValidator ID="rfvRepetirSenha" runat="server" ControlToValidate="txbRepetirSenha" ErrorMessage="A Repetição Senha é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="register">*</asp:RequiredFieldValidator>
                            <asp:TextBox ID="txbRepetirSenha" runat="server" type="password" class="input" data-type="password"></asp:TextBox>
                        </div>
                        <div class="group">
                            <asp:ValidationSummary ID="vsCriarMensagem" runat="server" ForeColor="#E50914" ShowMessageBox="True" ShowSummary="False" ValidationGroup="register" />
                        </div>
                        <div class="group">
                            <asp:Button ID="btnCriar" runat="server" Text="Inscrever-se" type="submit" class="button" OnClick="btnCriar_Click" ValidationGroup="register" />
                        </div>
                        <div class="hr"></div>
                        <div class="foot-lnk">
                            <label class="foot-member" for="tab-1">
                            Já é membro?</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
