<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="prjVideolandia.Insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Videolândia - Cadastro</title>

    <link rel="stylesheet" href="Insert.css" />
    <link rel="shortcut icon" href="Imagens/favicon.ico" />
</head>
<body>
    <form id="frmInserir" runat="server">
        <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="up" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnInserirItem"/>
            </Triggers>

            <ContentTemplate>
                <div class="login-wrap">
                    <div class="login-html">
                        <input id="tab-1" type="radio" name="tab" class="sign-in" checked="checked" /><label for="tab-1" class="tab">Adicionar Item</label>
                        <input id="tab-2" type="radio" name="tab" class="sign-up" /><label for="tab-2" class="tab">Adicionar Gênero</label>
                        <div class="additem-form">
                            <div class="sign-in-htm">
                                <div class="group">
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCodigoBarra" runat="server" Text="Código de Barra" CssClass="label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvCodigoBarra" runat="server" ControlToValidate="txbCodigoBarra" ErrorMessage="O Código de Barra é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="item">*</asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txbCodigoBarra" runat="server" CssClass="input" placeholder="0000000000000" MaxLength="13"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTitulo" runat="server" Text="Titulo do Filme" CssClass="label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txbTitulo" ErrorMessage="O Titulo do Item é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="item">*</asp:RequiredFieldValidator>
                                                <asp:TextBox ID="txbTitulo" runat="server" CssClass="input" placeholder="Ex. Avatar"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div class="group">
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneros" runat="server" Text="Genêros" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGenerosAdicionados" runat="server" Text="Genêros Adicionados" CssClass="label"></asp:Label>
                                                <asp:CustomValidator ID="cvlbGenerosAdicionados" runat="server" ErrorMessage="Adicione ao menos um Gênero!" ClientValidationFunction="ValidatelbGenerosAdicionados" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="item">*</asp:CustomValidator>

                                                <script type="text/javascript">
                                                    function ValidatelbGenerosAdicionados(sender, args) {
                                                        var options = document.getElementById("<%=lbGenerosAdicionados.ClientID%>").options;
                                                        if (options.length > 0) {
                                                            args.IsValid = true;
                                                        }
                                                        else {
                                                            args.IsValid = false;
                                                        }
                                                    }
                                                </script>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlGeneros" runat="server" CssClass="drop-list" BackColor="#171718"></asp:DropDownList>
                                                <br />
                                                <br />
                                                <asp:Button ID="btnAdicionarGenero" runat="server" Text="Adicionar Genêro" OnClick="btnAdicionarGenero_Click" CssClass="button" />
                                                <br />
                                                <asp:Button ID="btnRemoverGenero" runat="server" Text="Remover Genêro" OnClick="btnRemoverGenero_Click" CssClass="button" />
                                            </td>
                                            <td>
                                                <asp:ListBox ID="lbGenerosAdicionados" runat="server" SelectionMode="Single" CssClass="list"></asp:ListBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div class="group">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTipo" runat="server" Text="Tipo do Item" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPreco" runat="server" Text="Preço de Compra" CssClass="label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvPreco" runat="server" ControlToValidate="txbPreco" ErrorMessage="O Preço é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="item">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblValor" runat="server" Text="Valor do Aluguel" CssClass="label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvValor" runat="server" ControlToValidate="txbValor" ErrorMessage="O Valor é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="item">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSituacao" runat="server" Text="Situação" CssClass="label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="drop-list" BackColor="#171718">
                                                    <asp:ListItem Value="false">DVD</asp:ListItem>
                                                    <asp:ListItem Value="true">Blu-Ray</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txbPreco" runat="server" CssClass="input" placeholder="R$ 00,00"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txbValor" runat="server" CssClass="input" placeholder="R$ 00,00"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlSituacao" runat="server" CssClass="drop-list" BackColor="#171718">
                                                    <asp:ListItem Value="false">Locado</asp:ListItem>
                                                    <asp:ListItem Value="true">Disponível</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div class="group">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLancamento" runat="server" Text="Lançamento" CssClass="label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Calendar ID="cdLancamento" runat="server" CssClass="calendar" BorderStyle="NotSet" DayNameFormat="FirstLetter" DayHeaderStyle-VerticalAlign="Middle" DayHeaderStyle-HorizontalAlign="Center" SelectedDayStyle-BackColor="#E50914" ShowGridLines="False" TitleStyle-BackColor="#E50914" WeekendDayStyle-ForeColor="#E50914" DayStyle-ForeColor="White" DayStyle-CssClass="day"></asp:Calendar>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div class="group">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAtores" runat="server" Text="Atores" CssClass="label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPersonagens" runat="server" Text="Personagens" CssClass="label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvPersonagem" runat="server" ControlToValidate="txbNomePersonagem" ErrorMessage="O Nome do Personagem é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="actor">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlAtores" runat="server" CssClass="drop-list" BackColor="#171718"></asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txbNomePersonagem" runat="server" CssClass="input" placeholder="Ex. Batman"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Button ID="btnAdicionarAtores" runat="server" Text="Adicionar Ator" OnClick="btnAdicionarAtor_Click" CssClass="button" ValidationGroup="actor" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnRemoverAtor" runat="server" Text="Remover Ator" OnClick="btnRemoverAtor_Click" CssClass="button" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div class="group">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAtoresAdicionados" runat="server" Text="Atores Adicionados" CssClass="label"></asp:Label>
                                                <asp:CustomValidator ID="cvlbAtoresAdicionados" runat="server" ErrorMessage="Adicione ao menos um Ator!" ClientValidationFunction="ValidatelbAtoresAdicionados" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="item">*</asp:CustomValidator>

                                                <script type="text/javascript">
                                                    function ValidatelbAtoresAdicionados(sender, args) {
                                                        var options = document.getElementById("<%=lbAtoresAdicionados.ClientID%>").options;
                                                        if (options.length > 0) {
                                                            args.IsValid = true;
                                                        }
                                                        else {
                                                            args.IsValid = false;
                                                        }
                                                    }
                                                </script>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPersonagensAdicionados" runat="server" Text="Personagens Adicionados" CssClass="label"></asp:Label>
                                                <asp:CustomValidator ID="cvlbPersonagensAdicionados" runat="server" ErrorMessage="Adicione ao menos um Personagem!" ClientValidationFunction="ValidatelbPersonagensAdicionados" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="item">*</asp:CustomValidator>

                                                <script type="text/javascript">
                                                    function ValidatelbPersonagensAdicionados(sender, args) {
                                                        var options = document.getElementById("<%=lbPersonagensAdicionados.ClientID%>").options;
                                                        if (options.length > 0) {
                                                            args.IsValid = true;
                                                        }
                                                        else {
                                                            args.IsValid = false;
                                                        }
                                                    }
                                                </script>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:ListBox ID="lbAtoresAdicionados" runat="server" SelectionMode="Single" CssClass="sub-list"></asp:ListBox>
                                            </td>
                                            <td>
                                                <asp:ListBox ID="lbPersonagensAdicionados" runat="server" SelectionMode="Single" CssClass="sub-list"></asp:ListBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div class="group">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDiretor" runat="server" Text="Diretor" CssClass="label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvDiretor" runat="server" ControlToValidate="txbDiretor" ErrorMessage="O Nome do Diretor é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="item">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCapa" runat="server" Text="Foto de Capa" CssClass="label"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rfvCapa" runat="server" ControlToValidate="fuCapa" ErrorMessage="A Capa do Filme é Obrigatório!" ForeColor="#E50914" Font-Bold="True" Font-Size="Large" ValidationGroup="item">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txbDiretor" runat="server" CssClass="input" placeholder="Ex. Zack Snyder"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:FileUpload ID="fuCapa" runat="server" CssClass="input" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblImagemCarregada" runat="server" CssClass="label"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div class="group">
                                    <asp:ValidationSummary ID="vsItem" runat="server" ForeColor="#E50914" ShowMessageBox="True" ShowSummary="False" ValidationGroup="item" />
                                </div>

                                <div class="group">
                                    <asp:Button ID="btnInserirItem" runat="server" Text="Inserir Item" OnClick="btnInserir_Click" ValidationGroup="item" CssClass="button" />
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
