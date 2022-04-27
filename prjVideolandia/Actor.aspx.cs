using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjVideolandia
{
    public partial class Actor : System.Web.UI.Page
    {
        private Ator[] arrayAtor = new Ator[10];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["actor"] != null)
            {
                string ator;

                ator = Request.QueryString["actor"];

                int codigoAtor = Convert.ToInt32(ator);

                ObterInfoAtor(codigoAtor);
            }
            ReceberDados();
        }

        protected void btnConta_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Profile.aspx");
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("~/Login.aspx");
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

        private void ObterInfoAtor(int codigoAtor)
        {
            // Instanciar o ItemDAL;
            AtorDAL aDAL = new AtorDAL();

            Ator objAtor = new Ator();
            objAtor = aDAL.ProcurarAtorCodigo(codigoAtor);
            if (objAtor != null)
            {
                PreencherInfoAtor(objAtor);
            }
        }

        private void PreencherInfoAtor(Ator objAtor)
        {
            imgCapa.ImageUrl = objAtor.Foto;
            imgCapa.AlternateText = objAtor.NomeArtista;

            lblNome.Text = objAtor.NomeArtista;

            btnDataNascimento.Text = objAtor.DataNascimento.ToString("dd/MM/yyyy");

            btnPaisNascimento.Text = objAtor.PaisNascimento;
        }

        private void ReceberDados()
        {
            // Instanciar o ItemDAL;
            AtorDAL aDAL = new AtorDAL();

            Ator[] listaAtor = new Ator[10];
            listaAtor = aDAL.ProcurarAtor();
            if (listaAtor != null)
            {
                PreencherCarrossel(listaAtor);
            }
            arrayAtor = listaAtor;
        }

        private void PreencherCarrossel(Ator[] listaAtor)
        {
            // Setando os items recebido na pesquisa.
            if (listaAtor[0] != null)
            {
                ibtnAtor1.AlternateText = listaAtor[0].NomeArtista;
                ibtnAtor1.ImageUrl = listaAtor[0].Foto;

                lblAtor1.Text = listaAtor[0].NomeArtista;
            }

            if (listaAtor[1] != null)
            {
                ibtnAtor2.AlternateText = listaAtor[1].NomeArtista;
                ibtnAtor2.ImageUrl = listaAtor[1].Foto;

                lblAtor2.Text = listaAtor[1].NomeArtista;
            }

            if (listaAtor[2] != null)
            {
                ibtnAtor3.AlternateText = listaAtor[2].NomeArtista;
                ibtnAtor3.ImageUrl = listaAtor[2].Foto;

                lblAtor3.Text = listaAtor[2].NomeArtista;
            }

            if (listaAtor[3] != null)
            {
                ibtnAtor4.AlternateText = listaAtor[3].NomeArtista;
                ibtnAtor4.ImageUrl = listaAtor[3].Foto;

                lblAtor4.Text = listaAtor[3].NomeArtista;
            }

            if (listaAtor[4] != null)
            {
                ibtnAtor5.AlternateText = listaAtor[4].NomeArtista;
                ibtnAtor5.ImageUrl = listaAtor[4].Foto;

                lblAtor5.Text = listaAtor[4].NomeArtista;
            }

            if (listaAtor[5] != null)
            {
                ibtnAtor6.AlternateText = listaAtor[5].NomeArtista;
                ibtnAtor6.ImageUrl = listaAtor[5].Foto;

                lblAtor6.Text = listaAtor[5].NomeArtista;
            }

            if (listaAtor[6] != null)
            {
                ibtnAtor7.AlternateText = listaAtor[6].NomeArtista;
                ibtnAtor7.ImageUrl = listaAtor[6].Foto;

                lblAtor7.Text = listaAtor[6].NomeArtista;
            }

            if (listaAtor[7] != null)
            {
                ibtnAtor8.AlternateText = listaAtor[7].NomeArtista;
                ibtnAtor8.ImageUrl = listaAtor[7].Foto;

                lblAtor8.Text = listaAtor[7].NomeArtista;
            }

            if (listaAtor[8] != null)
            {
                ibtnAtor9.AlternateText = listaAtor[8].NomeArtista;
                ibtnAtor9.ImageUrl = listaAtor[8].Foto;

                lblAtor9.Text = listaAtor[8].NomeArtista;
            }

            if (listaAtor[9] != null)
            {
                ibtnAtor10.AlternateText = listaAtor[9].NomeArtista;
                ibtnAtor10.ImageUrl = listaAtor[9].Foto;

                lblAtor10.Text = listaAtor[9].NomeArtista;
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