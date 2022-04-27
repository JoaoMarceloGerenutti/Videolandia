using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmailDAL
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbVideolandia;Integrated Security=True";

        public void InserirEmail(Email objEmail)
        {
            // Criar um objeto do tipo conexão SQL.
            SqlConnection conn = new SqlConnection(connectionString);

            // Abrir conexão com o Banco de Dados.
            conn.Open();

            // Criar comando sql para inserção.
            string sql = "INSERT INTO Mensagens VALUES (@email, @assunto, @texto, @dataEnvio)";

            // Criar um objeto do tipo Comando SQL.
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email", objEmail.EmailRemetente);
            cmd.Parameters.AddWithValue("@assunto", objEmail.Assunto);
            cmd.Parameters.AddWithValue("@texto", objEmail.Mensagem);
            cmd.Parameters.AddWithValue("@dataEnvio", objEmail.DataEnvio);

            // Mandar executar o codigo no Banco de Dados.
            cmd.ExecuteNonQuery();

            // Fechar a conexão com o SQL.
            conn.Close();
        }

        public Email[] ObterEmailPorData()
        {
            Email[] arrayEmail = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Mensagens ORDER BY DataEnvio DESC";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                arrayEmail = new Email[10];

                for (int i = 0; i < 10; i++)
                {
                    if (dr.Read())
                    {
                        Email objEmail = new Email();

                        objEmail.CodigoEmail = Convert.ToInt32(dr["CodigoMensagem"]);
                        objEmail.EmailRemetente = dr["Email"].ToString();
                        objEmail.Assunto = dr["Assunto"].ToString();
                        objEmail.Mensagem = dr["Texto"].ToString();
                        objEmail.DataEnvio = Convert.ToDateTime(dr["DataEnvio"]);

                        arrayEmail[i] = objEmail;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayEmail;
        }
    }
}
