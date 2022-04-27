using DAL;
using Models;
using System;
using System.Web.Security;
using System.Web.UI;

namespace prjVideolandia
{
    public partial class Default : System.Web.UI.Page
    {
        private Item[] arrayItem = new Item[10];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                btnEntrar.Text = "Sair";
            }

            PreencherItems();
        }

        protected void btnVamos_Click(object sender, EventArgs e)
        {
            // Verifica se o usario já esta autenticado e redireciona ele para tela especifica.
            if (User.Identity.IsAuthenticated == true)
            {
                Response.Redirect("Videolandia.aspx");
            }
            else
            {
                // Salvando o email do txbEmail e passa
                string email = txbEmail.Text;
                if (email != "")
                {
                    Response.Redirect("~/Login.aspx?email=" + email);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('Preencha o campo E-mail!');", true);
                }
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();

                btnEntrar.Text = "Entrar";
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void PreencherItems()
        {
            // Instanciar o ItemDAL;
            ItemDAL iDAL = new ItemDAL();

            Item[] listaItem = new Item[10];
            listaItem = iDAL.ObterItemPorData();
            if (listaItem != null)
            {
                // Setando os items recebido na pesquisa.
                if (listaItem[0] != null)
                {
                    ibtn1.AlternateText = listaItem[0].Titulo;
                    ibtn1.ImageUrl = listaItem[0].Capa;

                    lbl1.Text = listaItem[0].Titulo;
                }

                if (listaItem[1] != null)
                {
                    ibtn2.AlternateText = listaItem[1].Titulo;
                    ibtn2.ImageUrl = listaItem[1].Capa;

                    lbl2.Text = listaItem[1].Titulo;
                }

                if (listaItem[2] != null)
                {
                    ibtn3.AlternateText = listaItem[2].Titulo;
                    ibtn3.ImageUrl = listaItem[2].Capa;

                    lbl3.Text = listaItem[2].Titulo;
                }

                if (listaItem[3] != null)
                {
                    ibtn4.AlternateText = listaItem[3].Titulo;
                    ibtn4.ImageUrl = listaItem[3].Capa;

                    lbl4.Text = listaItem[3].Titulo;
                }

                if (listaItem[4] != null)
                {
                    ibtn5.AlternateText = listaItem[4].Titulo;
                    ibtn5.ImageUrl = listaItem[4].Capa;

                    lbl5.Text = listaItem[4].Titulo;
                }

                if (listaItem[5] != null)
                {
                    ibtn6.AlternateText = listaItem[5].Titulo;
                    ibtn6.ImageUrl = listaItem[5].Capa;

                    lbl6.Text = listaItem[5].Titulo;
                }

                if (listaItem[6] != null)
                {
                    ibtn7.AlternateText = listaItem[6].Titulo;
                    ibtn7.ImageUrl = listaItem[6].Capa;

                    lbl7.Text = listaItem[6].Titulo;
                }

                if (listaItem[7] != null)
                {
                    ibtn8.AlternateText = listaItem[7].Titulo;
                    ibtn8.ImageUrl = listaItem[7].Capa;

                    lbl8.Text = listaItem[7].Titulo;
                }

                if (listaItem[8] != null)
                {
                    ibtn9.AlternateText = listaItem[8].Titulo;
                    ibtn9.ImageUrl = listaItem[8].Capa;

                    lbl9.Text = listaItem[8].Titulo;
                }

                if (listaItem[9] != null)
                {
                    ibtn10.AlternateText = listaItem[9].Titulo;
                    ibtn10.ImageUrl = listaItem[9].Capa;

                    lbl10.Text = listaItem[9].Titulo;
                }
                arrayItem = listaItem;
            }
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