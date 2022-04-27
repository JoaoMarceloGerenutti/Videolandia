using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AtorDAL
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbVideolandia;Integrated Security=True";

        public int QuantidadeAtores()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT COUNT(CodigoArtista) AS Quantidade FROM Artistas";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            int quantidadeItems = 0;
            if (dr.HasRows && dr.Read())
            {
                quantidadeItems = Convert.ToInt32(dr["Quantidade"]);
            }
            dr.Close();

            conn.Close();

            return quantidadeItems;
        }

        public Ator[] ObterTodosAtores()
        {
            Ator[] arrayAtores = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Artistas ORDER BY NomeArtista";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            int tamanhoArray = QuantidadeAtores();

            if (dr.HasRows)
            {
                arrayAtores = new Ator[tamanhoArray];

                for (int i = 0; i < arrayAtores.Length; i++)
                {
                    if (dr.Read())
                    {
                        Ator objAtor = new Ator();

                        objAtor.CodigoArtista = Convert.ToInt32(dr["CodigoArtista"]);
                        objAtor.NomeArtista = dr["NomeArtista"].ToString();

                        arrayAtores[i] = objAtor;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayAtores;
        }

        public Ator ProcurarAtorCodigo(int codigoAtor)
        {
            Ator objAtor = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Artistas WHERE CodigoArtista = @codigoAtor";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@codigoAtor", codigoAtor);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows && dr.Read())
            {
                objAtor = new Ator();

                objAtor.CodigoArtista = Convert.ToInt32(dr["CodigoArtista"]);
                objAtor.NomeArtista = dr["NomeArtista"].ToString();
                objAtor.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                objAtor.PaisNascimento = dr["PaisNascimento"].ToString();
                objAtor.Foto = dr["Foto"].ToString();
            }
            conn.Close();

            return objAtor;
        }

        public Ator[] ProcurarAtor()
        {
            Ator[] arrayAtor = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Artistas ORDER BY NomeArtista";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                arrayAtor = new Ator[10];

                for (int i = 0; i < 10; i++)
                {
                    if (dr.Read())
                    {
                        Ator objAtor = new Ator();

                        objAtor.CodigoArtista = Convert.ToInt32(dr["CodigoArtista"]);
                        objAtor.NomeArtista = dr["NomeArtista"].ToString();
                        objAtor.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                        objAtor.PaisNascimento = dr["PaisNascimento"].ToString();
                        objAtor.Foto = dr["Foto"].ToString();

                        arrayAtor[i] = objAtor;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayAtor;
        }

        public Ator[] ProcurarAtor(string busca)
        {
            Ator[] arrayAtor = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Artistas WHERE NomeArtista LIKE @nome ORDER BY NomeArtista";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nome", "%" + busca + "%");

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                arrayAtor = new Ator[10];

                for (int i = 0; i < 10; i++)
                {
                    if (dr.Read())
                    {
                        Ator objAtor = new Ator();

                        objAtor.CodigoArtista = Convert.ToInt32(dr["CodigoArtista"]);
                        objAtor.NomeArtista = dr["NomeArtista"].ToString();
                        objAtor.DataNascimento = Convert.ToDateTime(dr["DataNascimento"]);
                        objAtor.PaisNascimento = dr["PaisNascimento"].ToString();
                        objAtor.Foto = dr["Foto"].ToString();

                        arrayAtor[i] = objAtor;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayAtor;
        }

        public List<Ator> ObterAtoresItem(int codigoItem)
        {
            List<Ator> listaAtores = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT Artistas.CodigoArtista AS Codigo, Artistas.NomeArtista AS Nome" +
                " FROM Atua" +
                " INNER JOIN Artistas ON Atua.CodigoArtista = Artistas.CodigoArtista" +
                " INNER JOIN Items ON Atua.CodigoItem = Items.Codigo" +
                " WHERE Codigo = @codigoItem";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@codigoItem", codigoItem);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                listaAtores = new List<Ator>();

                while (dr.Read())
                {
                    Ator objAtor = new Ator();

                    objAtor.CodigoArtista = Convert.ToInt32(dr["Codigo"]);
                    objAtor.NomeArtista = dr["Nome"].ToString();

                    listaAtores.Add(objAtor);
                }
            }
            conn.Close();

            return listaAtores;
        }

        public List<string> ObterPersonagemAtores(int codigoItem)
        {
            List<string> listaPersonagem = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT Atua.NomePersonagem AS Personagem" +
                " FROM Atua" +
                " INNER JOIN Artistas ON Atua.CodigoArtista = Artistas.CodigoArtista" +
                " INNER JOIN Items ON Atua.CodigoItem = Items.Codigo" +
                " WHERE Codigo = @codigoItem";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@codigoItem", codigoItem);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                listaPersonagem = new List<string>();

                while (dr.Read())
                {
                    listaPersonagem.Add(dr["Personagem"].ToString());
                }
            }
            conn.Close();

            return listaPersonagem;
        }
    }
}
