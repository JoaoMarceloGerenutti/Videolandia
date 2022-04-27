<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Videolandia.aspx.cs" Inherits="prjVideolandia.Busca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Videolândia</title>

    <link rel="stylesheet" href="Videolandia.css" />
    <link rel="shortcut icon" href="Imagens/favicon.ico" />

    <link rel="stylesheet" href="https://unpkg.com/swiper/swiper-bundle.min.css" />

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
    <form id="frmVideolandia" runat="server">
        <nav>
            <ul class="menu">
                <li class="logo">
                    <img src="Imagens/Videolândia.png" alt="Netflix" draggable="false" /></li>
                <li class="item-left"><a href="Default.aspx">Página Inicial</a></li>
                <li class="item-left"><a href="Contact.aspx">Contato</a></li>
                <li class="space"></li>
                <li class="item button">
                    <div class="dropdown">
                        <asp:Image ID="imgPerfil" runat="server" onclick="dropDown()" class="dropbtn" ImageUrl="~/Imagens/Perfil.png" />
                        <div id="myDropdown" class="dropdown-content">
                            <div>
                                <asp:Button ID="btnConta" runat="server" Text="Conta" OnClick="btnConta_Click" CssClass="dropdown-button" />
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

                <li class="toggle"><span class="bars" /></li>
            </ul>
        </nav>

        <div class="search-bar">
            <asp:ImageButton ID="ibtnProcurar" runat="server" ImageUrl="~/Imagens/Busca.png" OnClick="ibtnProcurar_Click" CssClass="search" />
            <asp:TextBox ID="txbPesquisar" runat="server" class="input" placeholder="Pesquisar por titulos, genêros e atores"></asp:TextBox>
        </div>

        <div class="videolandia">
            <h1>Filmes e Séries</h1>
            <div class="swiper">
                <div class="swiper-wrapper">
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem1" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem1_Click" />
                        <asp:Label ID="lbl1" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem2" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem2_Click"/>
                        <asp:Label ID="lbl2" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem3" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem3_Click"/>
                        <asp:Label ID="lbl3" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem4" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem4_Click"/>
                        <asp:Label ID="lbl4" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem5" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem5_Click"/>
                        <asp:Label ID="lbl5" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem6" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem6_Click"/>
                        <asp:Label ID="lbl6" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem7" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem7_Click"/>
                        <asp:Label ID="lbl7" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem8" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem8_Click"/>
                        <asp:Label ID="lbl8" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem9" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem9_Click"/>
                        <asp:Label ID="lbl9" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:ImageButton ID="ibtnItem10" runat="server" AlternateText="Item Não Encontrado" class="movies" OnClick="ibtnItem10_Click"/>
                        <asp:Label ID="lbl10" runat="server" CssClass="movie-title"></asp:Label>
                    </div>
                </div>
                <div class="swiper-button-prev"></div>
                <div class="swiper-button-next"></div>
            </div>
        </div>

        <div class="videolandia">
            <h1>Genêros</h1>
            <div class="swiper">
                <div class="swiper-wrapper">
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero1" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero2" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero3" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero4" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero5" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero6" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero7" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero8" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero9" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                    <div class="swiper-slide">
                        <asp:Label ID="lblGenero10" runat="server" Text="Genêro Não Encontrado" CssClass="name"></asp:Label>
                    </div>
                </div>
                <div class="swiper-button-prev"></div>
                <div class="swiper-button-next"></div>
            </div>
        </div>

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
