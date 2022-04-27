using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

namespace prjVideolandia
{
    public partial class Busca : System.Web.UI.Page
    {
        private Item[] arrayItem = new Item[10];
        private Ator[] arrayAtor = new Ator[10];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["search"] != null)
            {
                string pesquisa;

                pesquisa = Request.QueryString["search"];
                txbPesquisar.Attributes.Add("placeholder", pesquisa);

                ReceberDados(pesquisa);
            }
            else
            {
                ReceberDados();
            }
        }

        protected void ibtnProcurar_Click(object sender, ImageClickEventArgs e)
        {
            string pesquisa = txbPesquisar.Text;

            Response.Redirect("~/Videolandia.aspx?search=" + pesquisa);
        }

        private void ReceberDados()
        {
            // Instanciar o ItemDAL;
            ItemDAL iDAL = new ItemDAL();

            Item[] listaItem = new Item[10];
            listaItem = iDAL.ProcurarItems();
            if (listaItem != null)
            {
                PreencherItems(listaItem);
            }
            arrayItem = listaItem;

            AtorDAL aDAL = new AtorDAL();

            Ator[] listaAtor = new Ator[10];
            listaAtor = aDAL.ProcurarAtor();
            if (listaAtor != null)
            {
                PreencherAtores(listaAtor);
            }
            arrayAtor = listaAtor;

            GeneroDAL gDAL = new GeneroDAL();

            Genero[] listaGenero = new Genero[10];
            listaGenero = gDAL.ProcurarGenero();
            if (listaGenero != null)
            {
                PreencherGeneros(listaGenero);
            }
        }

        private void ReceberDados(string pesquisa)
        {
            // Instanciar o ItemDAL;
            ItemDAL iDAL = new ItemDAL();

            Item[] listaItem = new Item[10];
            listaItem = iDAL.ProcurarItems(pesquisa);
            if (listaItem != null)
            {
                PreencherItems(listaItem);
            }

            AtorDAL aDAL = new AtorDAL();

            Ator[] listaAtor = new Ator[10];
            listaAtor = aDAL.ProcurarAtor(pesquisa);
            if (listaAtor != null)
            {
                PreencherAtores(listaAtor);
            }

            GeneroDAL gDAL = new GeneroDAL();

            Genero[] listaGenero = new Genero[10];
            listaGenero = gDAL.ProcurarGenero(pesquisa);
            if (listaGenero != null)
            {
                PreencherGeneros(listaGenero);
            }
        }

        private void PreencherItems(Item[] listaItem)
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

        private void PreencherAtores(Ator[] listaAtor)
        {
            // Setando os nomes dos atores recebido na pesquisa.
            if (listaAtor[0] != null)
            {
                lblAtor1.Text = listaAtor[0].NomeArtista;
                ibtnAtor1.ImageUrl = listaAtor[0].Foto;
            }

            if (listaAtor[1] != null)
            {
                lblAtor2.Text = listaAtor[1].NomeArtista;
                ibtnAtor2.ImageUrl = listaAtor[1].Foto;
            }

            if (listaAtor[2] != null)
            {
                lblAtor3.Text = listaAtor[2].NomeArtista;
                ibtnAtor3.ImageUrl = listaAtor[2].Foto;
            }

            if (listaAtor[3] != null)
            {
                lblAtor4.Text = listaAtor[3].NomeArtista;
                ibtnAtor4.ImageUrl = listaAtor[3].Foto;
            }

            if (listaAtor[4] != null)
            {
                lblAtor5.Text = listaAtor[4].NomeArtista;
                ibtnAtor5.ImageUrl = listaAtor[4].Foto;
            }

            if (listaAtor[5] != null)
            {
                lblAtor6.Text = listaAtor[5].NomeArtista;
                ibtnAtor6.ImageUrl = listaAtor[5].Foto;
            }

            if (listaAtor[6] != null)
            {
                lblAtor7.Text = listaAtor[6].NomeArtista;
                ibtnAtor7.ImageUrl = listaAtor[6].Foto;
            }

            if (listaAtor[7] != null)
            {
                lblAtor8.Text = listaAtor[7].NomeArtista;
                ibtnAtor8.ImageUrl = listaAtor[7].Foto;
            }

            if (listaAtor[8] != null)
            {
                lblAtor9.Text = listaAtor[8].NomeArtista;
                ibtnAtor9.ImageUrl = listaAtor[8].Foto;
            }

            if (listaAtor[9] != null)
            {
                lblAtor10.Text = listaAtor[9].NomeArtista;
                ibtnAtor10.ImageUrl = listaAtor[9].Foto;
            }
        }

        private void PreencherGeneros(Genero[] listaGenero)
        {
            // Setando os nomes dos generos recebido na pesquisa.
            if (listaGenero[0] != null)
            {
                lblGenero1.Text = listaGenero[0].NomeGenero;
            }

            if (listaGenero[1] != null)
            {
                lblGenero2.Text = listaGenero[1].NomeGenero;
            }

            if (listaGenero[2] != null)
            {
                lblGenero3.Text = listaGenero[2].NomeGenero;
            }

            if (listaGenero[3] != null)
            {
                lblGenero4.Text = listaGenero[3].NomeGenero;
            }

            if (listaGenero[4] != null)
            {
                lblGenero5.Text = listaGenero[4].NomeGenero;
            }

            if (listaGenero[5] != null)
            {
                lblGenero6.Text = listaGenero[5].NomeGenero;
            }

            if (listaGenero[6] != null)
            {
                lblGenero7.Text = listaGenero[6].NomeGenero;
            }

            if (listaGenero[7] != null)
            {
                lblGenero8.Text = listaGenero[7].NomeGenero;
            }

            if (listaGenero[8] != null)
            {
                lblGenero9.Text = listaGenero[8].NomeGenero;
            }

            if (listaGenero[9] != null)
            {
                lblGenero10.Text = listaGenero[9].NomeGenero;
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

        private void RedirecionarPaginaAtor(int codigoAtor)
        {
            Response.Redirect("~/Actor.aspx?actor=" + codigoAtor);
        }

        protected void ibtnAtor1_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[0].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }

        protected void ibtnAtor2_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[1].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }

        protected void ibtnAtor3_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[2].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }

        protected void ibtnAtor4_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[3].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }

        protected void ibtnAtor5_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[4].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }

        protected void ibtnAtor6_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[5].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }

        protected void ibtnAtor7_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[6].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }

        protected void ibtnAtor8_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[7].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }

        protected void ibtnAtor9_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[8].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }

        protected void ibtnAtor10_Click(object sender, ImageClickEventArgs e)
        {
            int codigo = arrayAtor[9].CodigoArtista;
            RedirecionarPaginaAtor(codigo);
        }
    }
}