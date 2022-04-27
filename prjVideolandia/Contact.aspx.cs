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
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

        protected void btnEnviarEmail_Click(object sender, EventArgs e)
        {
            EmailDAL eDAL = new EmailDAL();

            Email objEmail = new Email();
            objEmail.EmailRemetente = User.Identity.Name;
            objEmail.Assunto = txbAssunto.Text;
            objEmail.Mensagem = txbMensagem.Text;
            objEmail.DataEnvio = DateTime.Now;

            eDAL.InserirEmail(objEmail);

            RetornarVideolandia();
        }

        private void RetornarVideolandia()
        {
            Response.Redirect("~/Videolandia.aspx");
        }
    }
}