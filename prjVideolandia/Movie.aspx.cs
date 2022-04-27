using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjVideolandia
{
    public partial class Movie1 : System.Web.UI.Page
    {
        private Item[] arrayItem = new Item[10];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["movie"] != null)
            {
                string item;

                item = Request.QueryString["movie"];

                int codigoItem = Convert.ToInt32(item);

                ObterInfoItem(codigoItem);
            }
            ReceberDados();
        }

        private void ReceberDados()
        {
            // Instanciar o ItemDAL;
            ItemDAL iDAL = new ItemDAL();

            Item[] listaItem = new Item[10];
            listaItem = iDAL.ProcurarItems();
            if (listaItem != null)
            {
                PreencherCarrossel(listaItem);
            }
            arrayItem = listaItem;
        }

        private void PreencherCarrossel(Item[] listaItem)
        {
            // Setando os items recebido na pesquisa.
            if (listaItem[0] != null)
            {
                ibtnItem1.AlternateText = listaItem[0].Titulo;
                ibtnItem1.ImageUrl = listaItem[0].Capa;

                lbl1.Text = listaItem[0].Titulo;
            }

            if (listaItem[1] != null)
            {
                ibtnItem2.AlternateText = listaItem[1].Titulo;
                ibtnItem2.ImageUrl = listaItem[1].Capa;

                lbl2.Text = listaItem[1].Titulo;
            }

            if (listaItem[2] != null)
            {
                ibtnItem3.AlternateText = listaItem[2].Titulo;
                ibtnItem3.ImageUrl = listaItem[2].Capa;

                lbl3.Text = listaItem[2].Titulo;
            }

            if (listaItem[3] != null)
            {
                ibtnItem4.AlternateText = listaItem[3].Titulo;
                ibtnItem4.ImageUrl = listaItem[3].Capa;

                lbl4.Text = listaItem[3].Titulo;
            }

            if (listaItem[4] != null)
            {
                ibtnItem5.AlternateText = listaItem[4].Titulo;
                ibtnItem5.ImageUrl = listaItem[4].Capa;

                lbl5.Text = listaItem[4].Titulo;
            }

            if (listaItem[5] != null)
            {
                ibtnItem6.AlternateText = listaItem[5].Titulo;
                ibtnItem6.ImageUrl = listaItem[5].Capa;

                lbl6.Text = listaItem[5].Titulo;
            }

            if (listaItem[6] != null)
            {
                ibtnItem7.AlternateText = listaItem[6].Titulo;
                ibtnItem7.ImageUrl = listaItem[6].Capa;

                lbl7.Text = listaItem[6].Titulo;
            }

            if (listaItem[7] != null)
            {
                ibtnItem8.AlternateText = listaItem[7].Titulo;
                ibtnItem8.ImageUrl = listaItem[7].Capa;

                lbl8.Text = listaItem[7].Titulo;
            }

            if (listaItem[8] != null)
            {
                ibtnItem9.AlternateText = listaItem[8].Titulo;
                ibtnItem9.ImageUrl = listaItem[8].Capa;

                lbl9.Text = listaItem[8].Titulo;
            }

            if (listaItem[9] != null)
            {
                ibtnItem10.AlternateText = listaItem[9].Titulo;
                ibtnItem10.ImageUrl = listaItem[9].Capa;

                lbl10.Text = listaItem[9].Titulo;
            }
        }

        private void ObterInfoItem(int codigoItem)
        {
            // Instanciar o ItemDAL;
            ItemDAL iDAL = new ItemDAL();

            Item objItem = new Item();
            objItem = iDAL.ProcurarItemCodigo(codigoItem);
            if (objItem != null)
            {
                PreencherInfoItem(objItem);
            }

            GeneroDAL gDAL = new GeneroDAL();

            List<Genero> listaGenero = new List<Genero>();
            listaGenero = gDAL.ObterGenerosItem(codigoItem);
            if (listaGenero != null)
            {
                PreencherGeneros(listaGenero);
            }

            AtorDAL aDAL = new AtorDAL();

            List<Ator> listaAtor = new List<Ator>();
            listaAtor = aDAL.ObterAtoresItem(codigoItem);

            List<string> listaPersonagem = new List<string>();
            listaPersonagem = aDAL.ObterPersonagemAtores(codigoItem);

            if (listaAtor != null)
            {
                PreencherAtores(listaAtor, listaPersonagem);
            }
        }

        private void PreencherInfoItem(Item objItem)
        {
            imgCapa.ImageUrl = objItem.Capa;
            imgCapa.AlternateText = objItem.Titulo;

            lblTitulo.Text = objItem.Titulo;

            // Verifica se o item está locado.
            if (objItem.Situacao == false)
            {
                btnSituacao.Text = "Locado";
            }
            else
            {
                btnSituacao.Text = "Disponível";
            }

            // Verifica o tipo do item.
            if (objItem.Tipo == false)
            {
                btnTipo.Text = "DVD";
            }
            else
            {
                btnTipo.Text = "BLU-RAY";
            }

            btnValor.Text = objItem.Valor.ToString("C", CultureInfo.CurrentCulture);
            btnValor.Text += " / DIA";

            btnPreco.Text = objItem.Preco.ToString("C", CultureInfo.CurrentCulture);

            lblNomeDiretor.Text = objItem.Diretor;

            lblLancamento.Text = objItem.Lancamento.ToString("dd/MM/yyyy");
        }

        private void PreencherGeneros(List<Genero> listaGeneros)
        {
            Genero ultimoGenero = listaGeneros.Last();
            string generos = "";
            foreach (Genero genero in listaGeneros)
            {
                generos += genero.NomeGenero;

                if (ultimoGenero != genero)
                {
                    generos += ", ";
                }
                else
                {
                    break;
                }
            }
            lblListaGeneros.Text = generos;
        }

        private void PreencherAtores(List<Ator> listaAtores, List<string> listaPersonagem)
        {
            // Convertendo para Array para facilitar o acesso aos items.
            int tamanhoArray = listaPersonagem.Count();
            string[] arrayPersonagem = new string[tamanhoArray];
            arrayPersonagem = listaPersonagem.ToArray();

            int contador = 0;
            Ator ultimoAtor = listaAtores.Last();
            string atores = "";
            foreach (Ator ator in listaAtores)
            {
                atores += ator.NomeArtista;

                atores += " - ";
                atores += arrayPersonagem[contador];

                if (ultimoAtor != ator)
                {
                    atores += ", ";
                }
                else
                {
                    break;
                }
                contador++;
            }
            lblListaAtores.Text = atores;
        }

        protected void ibtnProcurar_Click(object sender, ImageClickEventArgs e)
        {
            // Salvando a procuta do txbProcurar e passando para a outra tela.
            string pesquisa = txbPesquisar.Text;
            if (pesquisa != "")
            {
                Response.Redirect("~/Movie.aspx?search=" + pesquisa);
            }
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("~/Login.aspx");
        }

        protected void btnConta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        private void RedirecionarPaginaItem(int codigoItem)
        {
            Response.Redirect("~/Movie.aspx?movie=" + codigoItem);
        }

        protected void ibtnItem1_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[0] != null)
            {
                int codigo = arrayItem[0].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }

        protected void ibtnItem2_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[1] != null)
            {
                int codigo = arrayItem[1].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }

        protected void ibtnItem3_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[2] != null)
            {
                int codigo = arrayItem[2].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }

        protected void ibtnItem4_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[3] != null)
            {
                int codigo = arrayItem[3].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }

        protected void ibtnItem5_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[4] != null)
            {
                int codigo = arrayItem[4].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }

        protected void ibtnItem6_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[5] != null)
            {
                int codigo = arrayItem[5].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }

        protected void ibtnItem7_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[6] != null)
            {
                int codigo = arrayItem[6].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }

        protected void ibtnItem8_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[7] != null)
            {
                int codigo = arrayItem[7].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }

        protected void ibtnItem9_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[8] != null)
            {
                int codigo = arrayItem[8].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }

        protected void ibtnItem10_Click(object sender, ImageClickEventArgs e)
        {
            if (arrayItem[9] != null)
            {
                int codigo = arrayItem[9].Codigo;
                RedirecionarPaginaItem(codigo);
            }
        }
    }
}