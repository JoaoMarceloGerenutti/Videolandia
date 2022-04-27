<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="prjVideolandia.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Videolândia - Contato</title>
    <link rel="stylesheet" href="Contact.css" />
    <link rel="shortcut icon" href="Imagens/favicon.ico" />

    <script>
        function dropDown() {
            document.getElementById("myDropdown").classList.toggle("show");
        }

        // Close the dropdown menu if the user clicks outside of it
        window.onclick = function (event) {
            if (!event.target.matches('.dropbtn')) {
                var dropdowns = document.getElementsByClassName("dropdown-content");
                var i;
                for (i = 0; i < dropdowns.length; i++) {
                    var openDropdown = dropdowns[i];
                    if (openDropdown.classList.contains('show')) {
                        openDropdown.classList.remove('show');
                    }
                }
            }
        }
    </script>

</head>
<body>
    <form id="frmContato" runat="server">
        <nav>
            <ul class="menu">
                <li class="logo">
                    <img src="Imagens/Videolândia.png" alt="Videolandia" draggable="false" /></li>
                <li class="item-left"><a href="Default.aspx">Página Inicial</a></li>
                <li class="item-left"><a href="Videolandia.aspx">Serviços</a></li>
                <li class="space"></li>
                <li class="item-right">
                    <asp:TextBox ID="txbPesquisar" runat="server" class="input" placeholder="Pesquisar por filmes, atores e diretores"></asp:TextBox></li>
                <li class="item-right">
                    <asp:ImageButton ID="ibtnProcurar" runat="server" ImageUrl="~/Imagens/Procurar.png" OnClick="ibtnProcurar_Click" /></li>
                <li class="item button">
                    <div class="dropdown">
                        <asp:Image ID="imgPerfil" runat="server" onclick="dropDown()" class="dropbtn" ImageUrl="~/Imagens/Perfil.png" />
                        <div id="myDropdown" class="dropdown-content">
                            <div>
                                <asp:Button ID="btnConta" runat="server" Text="Conta" CssClass="dropdown-button" OnClick="btnConta_Click" />
                            </div>
                            <div>
                                <asp:Button ID="btnConfiguracao" runat="server" Text="Configurações" CssClass="dropdown-button" />
                            </div>
                            <div>
                                <asp:Button ID="btnSair" runat="server" Text="Sair" OnClick="btnSair_Click" CssClass="dropdown-button" />
                            </div>
                        </div>
                    </div>
                </li>

                <li class="toggle"><span class="bars"></span></li>
            </ul>
        </nav>

        <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="up" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnEnviarEmail"/>
            </Triggers>

            <ContentTemplate>
                <div class="padding"></div>
                <div class="login-wrap">
                    <div class="login-html">
                        <input id="tab-1" type="radio" name="tab" class="sign-in" checked="checked" /><label for="tab-1" class="tab">E-mail</label>
                        <input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab"></label>
                        <div class="additem-form">
                            <div class="sign-in-htm">
                                <div class="group">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAssunto" runat="server" Text="Assunto" CssClass="label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvAssunto" runat="server" ControlToValidate="txbAssunto" ErrorMessage="O Assunto é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="contact">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txbAssunto" runat="server" CssClass="input" placeholder="Ex. Página do filme Luca não está funcionando"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblMensagem" runat="server" Text="Mensagem" CssClass="label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvMensagem" runat="server" ControlToValidate="txbMensagem" ErrorMessage="A Mensagem é Obrigatória!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="contact">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txbMensagem" runat="server" TextMode="MultiLine" cols="60" rows="12" class="input"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div class="group">
                                    <asp:ValidationSummary ID="vsEmail" runat="server" ForeColor="#E50914" ShowMessageBox="True" ShowSummary="False" ValidationGroup="contact"/>
                                </div>

                                <div class="group">
                                    <asp:Button ID="btnEnviarEmail" runat="server" Text="Enviar E-mail" CssClass="button" OnClick="btnEnviarEmail_Click" ValidationGroup="contact"/>
                                </div>

                                <div class="hr"></div>
                                <div class="foot-lnk">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
