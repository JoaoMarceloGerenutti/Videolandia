<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Movie.aspx.cs" Inherits="prjVideolandia.Movie1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Videolândia</title>
    <link rel="stylesheet" href="Movie.css" />
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
    <form id="frmMovie" runat="server">
        <nav>
            <ul class="menu">
                <li class="logo">
                    <img src="Imagens/Videolândia.png" alt="Netflix" draggable="false" /></li>
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
            <ContentTemplate>
                <div class="img-container">
                    <asp:Image ID="imgCapa" runat="server" CssClass="img-item" />
                    <div class="gradient"></div>
                    <asp:Label ID="lblTitulo" runat="server" CssClass="title"></asp:Label>
                    <asp:Button ID="btnSituacao" runat="server" CssClass="button-situation" />
                    <asp:Button ID="btnTipo" runat="server" CssClass="button-type" />
                    <asp:Button ID="btnValor" runat="server" CssClass="button-value" />
                    <asp:Button ID="btnPreco" runat="server" CssClass="button-price" />
                    <main class="main">
                        <div class="main-child">
                        </div>
                    </main>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <section class="section">
            <div class="container">
                <div class="grid">
                    <div class="item-description">
                        <table class="info">
                            <tr>
                                <td>
                                    <asp:Label ID="lblGeneros" runat="server" Text="Gêneros" CssClass="bold-description"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblListaGeneros" runat="server" CssClass="description"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDiretor" runat="server" Text="Direção" CssClass="bold-description"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblNomeDiretor" runat="server" CssClass="description"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAtores" runat="server" Text="Elenco" CssClass="bold-description"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblListaAtores" runat="server" CssClass="description"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDataLancamento" runat="server" Text="Data de Lançamento" CssClass="bold-description"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLancamento" runat="server" CssClass="description"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="problem">
                <asp:HyperLink ID="hlProblema" runat="server" CssClass="problem" NavigateUrl="~/Contact.aspx">Algo errado com o produto? Informe aqui</asp:HyperLink>
            </div>
        </section>

        <div class="videolandia">
            <h1>Filmes e Séries</h1>
            <div class="swiper">
                <div class="swiper-wrapper">
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem1" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem1_Click" /><asp:Label ID="lbl1" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem2" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem2_Click" /><asp:Label ID="lbl2" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem3" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem3_Click" /><asp:Label ID="lbl3" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem4" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem4_Click" /><asp:Label ID="lbl4" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem5" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem5_Click" /><asp:Label ID="lbl5" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem6" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem6_Click" /><asp:Label ID="lbl6" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem7" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem7_Click" /><asp:Label ID="lbl7" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem8" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem8_Click" /><asp:Label ID="lbl8" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem9" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem9_Click" /><asp:Label ID="lbl9" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem10" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem10_Click" /><asp:Label ID="lbl10" runat="server" CssClass="movie-title"></asp:Label>
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
