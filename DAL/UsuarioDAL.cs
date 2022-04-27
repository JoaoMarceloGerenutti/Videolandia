using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbVideolandia;Integrated Security=True";

        public void InserirUsuario(Usuario objUsuario)
        {
            // Criar um objeto do tipo conexão SQL.
            SqlConnection conn = new SqlConnection(connectionString);

            // Abrir conexão com o Banco de Dados.
            conn.Open();

            // Criar comando sql para inserção.
            string sql = "INSERT INTO Clientes VALUES (@email, @nome, @senha)";

            // Criar um objeto do tipo Comando SQL.
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Trocar os parametros do Comando(@nome por exemplo) pelas variaveis do objUsuario.
            cmd.Parameters.AddWithValue("@email", objUsuario.Email);
            cmd.Parameters.AddWithValue("@nome", objUsuario.Nome);
            cmd.Parameters.AddWithValue("@senha", objUsuario.Senha);

            // Mandar executar o codigo no Banco de Dados.
            cmd.ExecuteNonQuery();

            // Fechar a conexão com o SQL.
            conn.Close();
        }

        public bool ValidarUsuario(string email, string senha)
        {
            bool validado = false;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Clientes WHERE Email = @email AND Senha = @senha";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader dr = cmd.ExecuteReader();

            // HasRows retorna true caso tenha alguma linha ao executar o SELECT.
            validado = dr.HasRows;

            conn.Close();

            return validado;
        }

        public bool ProcurarEmail(string email)
        {
            bool emailEncontrado = false;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Clientes WHERE Email = @email";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email", email);

            SqlDataReader dr = cmd.ExecuteReader();

            // HasRows retorna true caso tenha alguma linha ao executar o SELECT.
            emailEncontrado = dr.HasRows;

            conn.Close();

            return emailEncontrado;
        }
    }
}
