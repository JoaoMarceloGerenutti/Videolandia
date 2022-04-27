<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actor.aspx.cs" Inherits="prjVideolandia.Actor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Videolândia - Ator</title>
    <link rel="stylesheet" href="Actor.css" />
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
    <form id="frmAtor" runat="server">
        <nav>
            <ul class="menu">
                <li class="logo">
                    <img src="Imagens/Videolândia.png" alt="Videolandia" draggable="false" /></li>
                <li class="item-left"><a href="Default.aspx">Página Inicial</a></li>
                <li class="item-left"><a href="Contact.aspx">Contato</a></li>
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
                                <asp:Button ID="btnConta" runat="server" Text="Conta" CssClass="dropdown-button" OnClick="btnConta_Click"/>
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
            <ContentTemplate>
                <div class="img-container">
                    <asp:Image ID="imgCapa" runat="server" CssClass="img-actor" />
                    <div class="gradient"></div>
                    <asp:Label ID="lblNome" runat="server" CssClass="actor-name"></asp:Label>
                    <asp:Button ID="btnDataNascimento" runat="server" CssClass="button-birthdata" />
                    <asp:Button ID="btnPaisNascimento" runat="server" CssClass="button-country" />
                    <main class="main">
                        <div class="main-child">
                        </div>
                    </main>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="videolandia">
            <h1>Atores</h1>
            <div class="swiper">
                <div class="swiper-wrapper">
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor1" runat="server" class="movies" OnClick="ibtnAtor1_Click"/>
                        <asp:Label ID="lblAtor1" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor2" runat="server" class="movies" OnClick="ibtnAtor2_Click"/>
                        <asp:Label ID="lblAtor2" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor3" runat="server" class="movies" OnClick="ibtnAtor3_Click"/>
                        <asp:Label ID="lblAtor3" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor4" runat="server" class="movies" OnClick="ibtnAtor4_Click"/>
                        <asp:Label ID="lblAtor4" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor5" runat="server" class="movies" OnClick="ibtnAtor5_Click"/>
                        <asp:Label ID="lblAtor5" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor6" runat="server" class="movies" OnClick="ibtnAtor6_Click"/>
                        <asp:Label ID="lblAtor6" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor7" runat="server" class="movies" OnClick="ibtnAtor7_Click"/>
                        <asp:Label ID="lblAtor7" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor8" runat="server" class="movies" OnClick="ibtnAtor8_Click"/>
                        <asp:Label ID="lblAtor8" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor9" runat="server" class="movies" OnClick="ibtnAtor9_Click"/>
                        <asp:Label ID="lblAtor9" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnAtor10" runat="server" class="movies" OnClick="ibtnAtor10_Click"/>
                        <asp:Label ID="lblAtor10" runat="server" Text="Ator Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                </div>
                <div class="swiper-button-prev"></div>
                <div class="swiper-button-next"></div>
            </div>
        </div>

        <script>
            var swiper = new Swiper('.swiper', {
                slidesPerView: 6,
                spaceBetween: 60,
                slidesPerGroup: 2,
                loop: true,
                loopFillGroupWithBlank: true,
                pagination: {
                    el: '.swiper-pagination',
                    clickable: true,
                },
                navigation: {
                    nextE1: '.swiper-button-next',
                    prevE1: '.swiper-button-prev',
                }
            });
        </script>

        <footer class="footer">
            <p>Copyright © 2021 Videolândia todos os direitos reservados. </p>
        </footer>
    </form>
</body>
</html>
