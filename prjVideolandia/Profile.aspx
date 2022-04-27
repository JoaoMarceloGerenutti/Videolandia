<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="prjVideolandia.Movie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Videolândia - Perfil</title>
    <link rel="stylesheet" href="Profile.css" />
    <link rel="stylesheet" href="https://unpkg.com/swiper/swiper-bundle.min.css" />
    <link rel="shortcut icon" href="Imagens/favicon.ico" />

    <script src="https://unpkg.com/swiper/swiper-bundle.js"></script>
    <script src="https://unpkg.com/swiper/swiper-bundle.min.js"></script>

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
    <form id="frmProfile" runat="server">
        <nav>
            <ul class="menu">
                <li class="logo">
                    <img src="Imagens/Videolândia.png" alt="Videolandia" draggable="false" /></li>
                <li class="item-left"><a href="Default.aspx">Página Inicial</a></li>
                <li class="item-left"><a href="Contact.aspx">Contato</a></li>
                <li class="item-left"><a href="Videolandia.aspx">Serviços</a></li>
                <li class="space"></li>
                <li class="item-right">
                    <asp:TextBox ID="txbPesquisar" runat="server" class="input" placeholder="Pesquisar por filmes, séries e muito mais"></asp:TextBox></li>
                <li class="item-right">
                    <asp:ImageButton ID="ibtnProcurar" runat="server" ImageUrl="~/Imagens/Procurar.png" OnClick="ibtnProcurar_Click" CssClass="search" /></li>
                <li class="item button">
                    <div class="dropdown">
                        <asp:Image ID="imgPerfil" runat="server" onclick="dropDown()" class="dropbtn" ImageUrl="~/Imagens/Perfil.png" />
                        <div id="myDropdown" class="dropdown-content">
                            <div>
                                <asp:Button ID="btnCadastro" runat="server" Text="Cadstro" OnClick="btnCadastro_Click" CssClass="dropdown-button" />
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
                                        <asp:Label ID="lblA1" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM1" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>

                        <div class="group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblA2" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM2" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>

                        <div class="group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblA3" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM3" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>

                        <div class="group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblA4" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM4" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>

                        <div class="group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblA5" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM5" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>

                        <div class="group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblA6" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM6" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>

                        <div class="group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblA7" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM7" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>

                        <div class="group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblA8" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM8" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>

                        <div class="group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblA9" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM9" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>

                        <div class="group">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblA10" runat="server" Text="Email não encontrado" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblM10" runat="server" CssClass="label"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <div class="hr"></div>
                            <div class="foot-lnk">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
