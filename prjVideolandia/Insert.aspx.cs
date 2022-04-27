using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace prjVideolandia
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.Name == "admin@admin.com")
                {
                    // Popular os DropDownList com os dados do banco.
                    PopularListaGeneros();

                    PopularListaAtores();
                } 
                else
                {
                    NegarPermissao();
                }
            }
        }

        private void NegarPermissao()
        {
            Response.Redirect("~/Videolandia.aspx");
        }

        private void PopularListaGeneros()
        {
            GeneroDAL gDAL = new GeneroDAL();

            int tamanhoArray = gDAL.QuantidadeGeneros();
            Genero[] arrayGeneros = new Genero[tamanhoArray];

            arrayGeneros = gDAL.ObterTodosGeneros();

            for (int i = 0; i < arrayGeneros.Length; i++)
            {
                ListItem item = new ListItem(arrayGeneros[i].NomeGenero, arrayGeneros[i].CodigoGenero.ToString());
                ddlGeneros.Items.Insert(i, item);
            }
            ddlGeneros.DataBind();
        }

        private void PopularListaAtores()
        {
            AtorDAL aDAL = new AtorDAL();

            int tamanhoArray = aDAL.QuantidadeAtores();
            Ator[] arrayAtores = new Ator[tamanhoArray];

            arrayAtores = aDAL.ObterTodosAtores();

            for (int i = 0; i < arrayAtores.Length; i++)
            {
                ListItem item = new ListItem(arrayAtores[i].NomeArtista, arrayAtores[i].CodigoArtista.ToString());
                ddlAtores.Items.Insert(i, item);
            }
            ddlAtores.DataBind();
        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            // Instanciar o ItemDAL;
            ItemDAL iDAL = new ItemDAL();

            Item objItem = new Item();
            objItem.CodigoBarra = txbCodigoBarra.Text;
            objItem.Titulo = txbTitulo.Text;
            objItem.Lancamento = cdLancamento.SelectedDate;
            objItem.Tipo = Convert.ToBoolean(ddlTipo.SelectedValue);
            objItem.Preco = Convert.ToSingle(txbPreco.Text);
            objItem.DataAquisicao = DateTime.Now;
            objItem.Valor = Convert.ToSingle(txbValor.Text);
            objItem.Situacao = Convert.ToBoolean(ddlSituacao.SelectedValue);
            objItem.Diretor = txbDiretor.Text;

            // Salva o arquivo na maquina, o diretorio varia de maquina para maquina (AVA).
            string diretorioUpload = "C:\\Users\\GAMER\\Desktop\\prjVideolandia\\prjVideolandia\\Imagens\\Upload\\Filmes e Series\\";
            string nomeArquivo = fuCapa.PostedFile.FileName;

            // Salva o arquivo passando o parametro de lugar.
            fuCapa.PostedFile.SaveAs(diretorioUpload + nomeArquivo);

            string diretorio = "~/Imagens/Upload/Filmes e Series/" + nomeArquivo;
            objItem.Capa = diretorio;

            iDAL.InserirItem(objItem);

            // Obtendo o codigo do ultimo item.
            int codigoItem = iDAL.ObterCodigoUltimoItem();

            // Chamando os metodos para adicionar nas tabelas do banco Contem e Atua.
            InserirGeneros(codigoItem);

            InserirAtores(codigoItem);

            LimpaCampos();
        }

        private void InserirGeneros(int codigoItem)
        {
            // Instanciar o ItemDAL;
            ItemDAL iDAL = new ItemDAL();

            // Fazer a contagem de Generos selecionados.
            int contagemGeneros = lbGenerosAdicionados.Items.Count;

            int[] arrayCodigosGeneros = new int[contagemGeneros];

            // Obter uma array dos codigos dos generos selecionados.
            int contadorLista = 0;
            foreach (ListItem item in lbGenerosAdicionados.Items)
            {
                arrayCodigosGeneros[contadorLista] = Convert.ToInt32(item.Value);
                contadorLista++;
            }

            // Fazer a relação dos codigos na tabela Contem do banco, passando o codigoItem e os codigos dos Generos selecionados.
            for (int i = 0; i < arrayCodigosGeneros.Length; i++)
            {
                iDAL.InserirGenerosItem(codigoItem, arrayCodigosGeneros[i]);
            }
        }

        private void InserirAtores(int codigoItem)
        {
            // Instanciar o ItemDAL;
            ItemDAL iDAL = new ItemDAL();

            // Fazer a contagem de Atores selecionados.
            int contagemAtores = lbAtoresAdicionados.Items.Count;

            int[] arrayCodigosAtores = new int[contagemAtores];

            // Obter uma array dos codigos dos Atores selecionados.
            int contadorLista = 0;
            foreach (ListItem item in lbAtoresAdicionados.Items)
            {
                arrayCodigosAtores[contadorLista] = Convert.ToInt32(item.Value);
                contadorLista++;
            }

            string[] arrayNomePersonagem = new string[arrayCodigosAtores.Length];

            // Obter uma array dos nomes dos personagens interpretado pelos Atores selecionados.
            contadorLista = 0;
            foreach (ListItem item in lbPersonagensAdicionados.Items)
            {
                arrayNomePersonagem[contadorLista] = item.Text;
                contadorLista++;
            }

            // Fazer a relação dos codigos na tabela Atua do banco, passando o codigoItem e os codigos dos Atores selecionados.
            for (int i = 0; i < arrayCodigosAtores.Length; i++)
            {
                iDAL.InserirAtoresItem(codigoItem, arrayCodigosAtores[i], arrayNomePersonagem[i]);
            }
        }

        protected void btnAdicionarGenero_Click(object sender, EventArgs e)
        {
            bool generoRepetido = false;

            if (lbGenerosAdicionados.Items != null)
            {
                string itemSelecionado = ddlGeneros.SelectedItem.Value;
                foreach (ListItem item in lbGenerosAdicionados.Items)
                {
                    if (item.Value == itemSelecionado)
                    {
                        generoRepetido = true;
                        break;
                    }
                }
            }

            if (generoRepetido == false)
            {
                GeneroDAL gDAL = new GeneroDAL();

                int tamanhoArray = gDAL.QuantidadeGeneros();
                Genero[] arrayGeneros = new Genero[tamanhoArray];

                arrayGeneros = gDAL.ObterTodosGeneros();

                int posicaoItem = Convert.ToInt32(ddlGeneros.SelectedIndex);
                ListItem item = new ListItem(arrayGeneros[posicaoItem].NomeGenero, arrayGeneros[posicaoItem].CodigoGenero.ToString());

                lbGenerosAdicionados.Items.Add(item);

                lbGenerosAdicionados.DataBind();
            }
            else
            {
                string genero = ddlGeneros.SelectedItem.Text.ToLower();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", $"alert('O Gênero {genero} já está na lista!');", true);
            }
        }

        protected void btnRemoverGenero_Click(object sender, EventArgs e)
        {
            int indexSelecionado = lbGenerosAdicionados.SelectedIndex;
            lbGenerosAdicionados.Items.RemoveAt(indexSelecionado);
        }

        protected void btnAdicionarAtor_Click(object sender, EventArgs e)
        {
            bool personagemRepetido = false;
            if (lbPersonagensAdicionados.Items != null)
            {
                string personagemDigitado = txbNomePersonagem.Text.ToUpper();
                foreach (ListItem personagemInserido in lbPersonagensAdicionados.Items)
                {
                    if (personagemInserido.Value.ToUpper() == personagemDigitado)
                    {
                        personagemRepetido = true;
                        break;
                    }
                }
            }

            if (personagemRepetido == false)
            {
                AtorDAL aDAL = new AtorDAL();

                // Adiciona o Ator e seu Codigo em uma lista.
                int tamanhoArray = aDAL.QuantidadeAtores();
                Ator[] arrayAtores = new Ator[tamanhoArray];

                arrayAtores = aDAL.ObterTodosAtores();

                int posicaoItem = Convert.ToInt32(ddlAtores.SelectedIndex);
                ListItem item = new ListItem(arrayAtores[posicaoItem].NomeArtista, arrayAtores[posicaoItem].CodigoArtista.ToString());

                lbAtoresAdicionados.Items.Add(item);

                // Adiciona o nome do personagem que o Ator interpretou em uma lista.
                tamanhoArray = aDAL.QuantidadeAtores();
                string[] arrayPersonagens = new string[tamanhoArray];

                string nomePersonagem = txbNomePersonagem.Text;
                ListItem personagem = new ListItem(nomePersonagem, nomePersonagem);

                lbPersonagensAdicionados.Items.Add(personagem);

                // Atualizando as listBox.
                lbAtoresAdicionados.DataBind();
                lbPersonagensAdicionados.DataBind();
            }
            else
            {
                string nomePersonagem = txbNomePersonagem.Text.ToLower();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", $"alert('O Personagem {nomePersonagem} já está na lista!');", true);
            }
        }

        protected void btnRemoverAtor_Click(object sender, EventArgs e)
        {
            int indexSelecionado = lbAtoresAdicionados.SelectedIndex;
            if (indexSelecionado != -1)
            {
                lbAtoresAdicionados.Items.RemoveAt(indexSelecionado);
                lbPersonagensAdicionados.Items.RemoveAt(indexSelecionado);

                lbAtoresAdicionados.DataBind();
                lbPersonagensAdicionados.DataBind();
            }
        }

        private void LimpaCampos()
        {
            txbCodigoBarra.Text = "";
            txbTitulo.Text = "";
            lbGenerosAdicionados.Items.Clear();
            txbPreco.Text = "";
            txbValor.Text = "";
            cdLancamento.SelectedDate = DateTime.Today;
            txbNomePersonagem.Text = "";
            lbAtoresAdicionados.Items.Clear();
            lbPersonagensAdicionados.Items.Clear();
            txbDiretor.Text = "";
        }
    }
}