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
    public partial class Movie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (User.Identity.Name == "admin@admin.com")
                {
                    PopularEmail();
                }
                else
                {
                    NegarPermissao();
                }
            }
        }

        private void PopularEmail()
        {
            EmailDAL eDAL = new EmailDAL();

            Email[] arrayEmail = new Email[10];
            arrayEmail = eDAL.ObterEmailPorData();

            if (arrayEmail != null)
            {
                PreencherEmail(arrayEmail);
            }
        }

        private void NegarPermissao()
        {
            Response.Redirect("~/Videolandia.aspx");
        }

        private void PreencherEmail(Email[] arrayEmail)
        {
            string assunto;
            string mensagem;

            if (arrayEmail[0] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[0].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[0].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[0].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[0].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA1.Text = assunto;

                mensagem = arrayEmail[0].Mensagem;
                lblM1.Text = mensagem;
            }

            if (arrayEmail[1] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[1].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[1].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[1].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[1].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA2.Text = assunto;

                mensagem = arrayEmail[1].Mensagem;
                lblM2.Text = mensagem;
            }

            if (arrayEmail[2] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[2].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[2].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[2].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[2].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA3.Text = assunto;

                mensagem = arrayEmail[2].Mensagem;
                lblM3.Text = mensagem;
            }

            if (arrayEmail[3] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[3].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[3].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[3].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[3].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA4.Text = assunto;

                mensagem = arrayEmail[3].Mensagem;
                lblM4.Text = mensagem;
            }

            if (arrayEmail[4] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[4].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[4].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[4].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[4].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA5.Text = assunto;

                mensagem = arrayEmail[4].Mensagem;
                lblM5.Text = mensagem;
            }

            if (arrayEmail[5] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[5].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[5].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[5].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[5].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA6.Text = assunto;

                mensagem = arrayEmail[5].Mensagem;
                lblM6.Text = mensagem;
            }

            if (arrayEmail[6] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[6].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[6].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[6].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[6].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA7.Text = assunto;

                mensagem = arrayEmail[6].Mensagem;
                lblM7.Text = mensagem;
            }

            if (arrayEmail[7] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[7].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[7].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[7].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[7].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA8.Text = assunto;

                mensagem = arrayEmail[7].Mensagem;
                lblM8.Text = mensagem;
            }

            if (arrayEmail[8] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[8].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[8].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[8].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[8].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA9.Text = assunto;

                mensagem = arrayEmail[8].Mensagem;
                lblM9.Text = mensagem;
            }

            if (arrayEmail[9] != null)
            {
                assunto = "{ ";
                assunto += arrayEmail[9].CodigoEmail;
                assunto += " } ";

                assunto += arrayEmail[9].Assunto;

                assunto += " - Enviado por: ";
                assunto += arrayEmail[9].EmailRemetente;

                assunto += " (";
                assunto += arrayEmail[9].DataEnvio.ToString("dd/MM/yyyy");
                assunto += ")";

                lblA10.Text = assunto;

                mensagem = arrayEmail[9].Mensagem;
                lblM10.Text = mensagem;
            }
        }

        protected void ibtnProcurar_Click(object sender, ImageClickEventArgs e)
        {
            // Salvando a procuta do txbProcurar e passando para a outra tela.
            string pesquisa = txbPesquisar.Text;
            if (pesquisa != "")
            {
                Response.Redirect("~/Videolandia.aspx?search=" + pesquisa);
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

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Insert.aspx");
        }
    }
}