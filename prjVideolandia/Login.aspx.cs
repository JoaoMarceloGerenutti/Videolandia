using DAL;
using Models;
using System;
using System.Web.UI;

namespace prjVideolandia
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Pegando o email passado na pagina anterior.
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["email"] != null)
                {
                    string email = Request.QueryString["email"];
                    Login1.UserName = email;
                }
            }
        }

        protected void btnCriar_Click(object sender, EventArgs e)
        {
            string email = txbCriarEmail.Text;

            // Instanciar o UsuarioDAL;
            UsuarioDAL uDAL = new UsuarioDAL();

            // Verificando se o email já foi cadastrado no banco de dados.
            bool emailEncontrado = uDAL.ProcurarEmail(email);
            if (emailEncontrado == true)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alerta", "alert('Esse E-mail já foi Cadastrado!');", true);
            }
            else
            {
                // Preencher um objeto do tipo Usuario com os dados de cadastro.
                Usuario objUsuario = new Usuario();
                objUsuario.Email = txbCriarEmail.Text;
                objUsuario.Nome = txbNome.Text;
                objUsuario.Senha = Criptografia.GetMD5Hash(txbCriarSenha.Text);

                // Chamando o metodo InserirUsuario do DAL.
                uDAL.InserirUsuario(objUsuario);
            }
            // Salva o email para passar para o login.
            string emailSalvo = txbCriarEmail.Text;

            // Chamando o metodo LimpaCampos.
            LimpaCampos();

            // Passa o email salvo para o login.
            Login1.UserName = emailSalvo;
        }

        private void LimpaCampos()
        {
            // Cadastro
            txbCriarEmail.Text = "";
            txbCriarSenha.Text = "";
            txbRepetirSenha.Text = "";
            txbNome.Text = "";
        }

        protected void Login1_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
        {
            string email = Login1.UserName;
            string senhaHash = Criptografia.GetMD5Hash(Login1.Password);

            // Instanciar o UsuarioDAL;
            UsuarioDAL uDAl = new UsuarioDAL();

            e.Authenticated = uDAl.ValidarUsuario(email, senhaHash);
        }
    }
}