<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="prjVideolandia.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Videolândia - Alugue filmes e series para assistir no conforto da sua casa</title>
    <link rel="stylesheet" href="Default.css" />
    <link rel="stylesheet" href="https://unpkg.com/swiper/swiper-bundle.min.css" />
    <link rel="shortcut icon" href="Imagens/favicon.ico" />

    <script src="https://unpkg.com/swiper/swiper-bundle.js"></script>
    <script src="https://unpkg.com/swiper/swiper-bundle.min.js"></script>
</head>

<body>
    <form class="form-cta" runat="server">
        <header class="header">
            <img src="Imagens/Videolândia.png" alt="Netflix" draggable="false" />
            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="login" OnClick="btnEntrar_Click" />
        </header>

        <main class="main">
            <div class="main-child">
                <h1>Filmes, séries e muito mais.</h1>
                <span>Alugue filmes em DVD, Blu-ray e Blu-ray 3D. </span>
                <div class="cta">
                    <asp:TextBox ID="txbEmail" runat="server" type="text" placeholder="Email" CssClass="input"></asp:TextBox>
                    <asp:Button ID="btnVamos" runat="server" Text="Vamos lá" CssClass="button" OnClick="btnVamos_Click" />
                </div>
                <p>
                    Pronto para alugar? Informe seu email para criar ou entrar em sua conta.
                </p>
            </div>
            <div class="gradient"></div>
        </main>

        <section class="section">
            <div class="videolandia">
                <h1>Filmes e séries adicionados recentemente</h1>
                <div class="swiper">
                    <div class="swiper-wrapper">
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn1" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem1_Click"/>
                            <asp:Label ID="lbl1" runat="server" CssClass="name"></asp:Label>
                        </div>
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn2" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem2_Click"/>
                            <asp:Label ID="lbl2" runat="server" CssClass="name"></asp:Label>
                        </div>
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn3" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem3_Click"/>
                            <asp:Label ID="lbl3" runat="server" CssClass="name"></asp:Label>
                        </div>
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn4" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem4_Click"/>
                            <asp:Label ID="lbl4" runat="server" CssClass="name"></asp:Label>
                        </div>
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn5" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem5_Click"/>
                            <asp:Label ID="lbl5" runat="server" CssClass="name"></asp:Label>
                        </div>
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn6" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem6_Click"/>
                            <asp:Label ID="lbl6" runat="server" CssClass="name"></asp:Label>
                        </div>
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn7" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem7_Click"/>
                            <asp:Label ID="lbl7" runat="server" CssClass="name"></asp:Label>
                        </div>
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn8" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem8_Click"/>
                            <asp:Label ID="lbl8" runat="server" CssClass="name"></asp:Label>
                        </div>
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn9" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem9_Click"/>
                            <asp:Label ID="lbl9" runat="server" CssClass="name"></asp:Label>
                        </div>
                        <div class="swiper-slide">
                            <asp:ImageButton ID="ibtn10" AlternateText="Não Encontrado" runat="server" CssClass="movies" OnClick="ibtnItem10_Click"/>
                            <asp:Label ID="lbl10" runat="server" CssClass="name"></asp:Label>
                        </div>
                    </div>
                    <div class="swiper-button-prev"></div>
                    <div class="swiper-button-next"></div>
                </div>
            </div>
        </section>

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

        <section class="section">
            <div class="container">
                <div class="grid">
                    <div>
                        <h1>Aproveite na sua TV. </h1>
                        <p>
                            Assista em Smart TVs, aparelhos de Blu-ray e DVD.
                        </p>
                    </div>
                    <div class="img-tv">
                        <img src="Imagens/TV.png" alt="TV" draggable="false" />
                        <video class="video-tv" autoplay muted loop>
                            <source src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/video-tv-0819.m4v" type="video/mp4">
                        </video>
                    </div>
                </div>
            </div>
        </section>

        <section class="rent section">
            <div class="container">
                <div class="grid">
                    <div>
                        <h1>Assista no conforto da sua casa.</h1>
                        <p>
                            Alugue os nossos filmes e assista no conforto do seu sofá.
                        </p>
                    </div>
                    <div class="img-tv">
                        <img src="Imagens/Conforto.jpg" alt="Alugue" draggable="false" />
                    </div>
                </div>
            </div>
        </section>

        <section class="computer section">
            <div class="container">
                <div class="grid">
                    <div>
                        <h1>Assista onde quiser.</h1>
                        <p>
                            Assista no seu computador ou notebook sem pagar a mais por isso.
                        </p>
                    </div>
                    <div class="img-tv">
                        <img src="Imagens/Computador.png" alt="Computador" draggable="false" />
                        <video class="video-tv" autoplay muted loop>
                            <source src="https://assets.nflxext.com/ffe/siteui/acquisition/ourStory/fuji/desktop/video-devices.m4v" type="video/mp4" />
                        </video>
                    </div>
                </div>
            </div>
        </section>

        <footer class="footer">
            <p>Copyright © 2021 Videolândia todos os direitos reservados. </p>
        </footer>
    </form>
</body>
</html>
