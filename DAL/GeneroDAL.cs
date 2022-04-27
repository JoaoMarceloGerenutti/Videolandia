using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GeneroDAL
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbVideolandia;Integrated Security=True";

        public int QuantidadeGeneros()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT COUNT(CodigoGenero) AS Quantidade FROM Generos";

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

        public Genero[] ObterTodosGeneros()
        {
            Genero[] arrayGeneros = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Generos ORDER BY NomeGenero";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            int tamanhoArray = QuantidadeGeneros();

            if (dr.HasRows)
            {
                arrayGeneros = new Genero[tamanhoArray];

                for (int i = 0; i < arrayGeneros.Length; i++)
                {
                    if (dr.Read())
                    {
                        Genero objGenero = new Genero();

                        objGenero.CodigoGenero = Convert.ToInt32(dr["CodigoGenero"]);
                        objGenero.NomeGenero = dr["NomeGenero"].ToString();

                        arrayGeneros[i] = objGenero;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayGeneros;
        }

        public Genero[] ProcurarGenero()
        {
            Genero[] arrayGeneros = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Generos ORDER BY NomeGenero";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                arrayGeneros = new Genero[10];

                for (int i = 0; i < 10; i++)
                {
                    if (dr.Read())
                    {
                        Genero objGenero = new Genero();

                        objGenero.CodigoGenero = Convert.ToInt32(dr["CodigoGenero"]);
                        objGenero.NomeGenero = dr["NomeGenero"].ToString();

                        arrayGeneros[i] = objGenero;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayGeneros;
        }

        public Genero[] ProcurarGenero(string busca)
        {
            Genero[] arrayGenero = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Generos WHERE NomeGenero LIKE @genero ORDER BY NomeGenero";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@genero", "%" + busca + "%");

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                arrayGenero = new Genero[10];

                for (int i = 0; i < 10; i++)
                {
                    if (dr.Read())
                    {
                        Genero objGenero = new Genero();

                        objGenero.CodigoGenero = Convert.ToInt32(dr["CodigoGenero"]);
                        objGenero.NomeGenero = dr["NomeGenero"].ToString();

                        arrayGenero[i] = objGenero;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayGenero;
        }

        public List<Genero> ObterGenerosItem(int codigoItem)
        {
            List<Genero> listaGeneros = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT Generos.CodigoGenero AS Codigo, Generos.NomeGenero AS Genero" +
                " FROM Contem" +
                " INNER JOIN Generos ON Contem.CodigoGenero = Generos.CodigoGenero" +
                " INNER JOIN Items ON Contem.CodigoItem = Items.Codigo" +
                " WHERE Codigo = @codigoItem";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@codigoItem", codigoItem);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                listaGeneros = new List<Genero>();

                while (dr.Read())
                {
                    Genero objGenero = new Genero();

                    objGenero.CodigoGenero = Convert.ToInt32(dr["Codigo"]);
                    objGenero.NomeGenero = dr["Genero"].ToString();

                    listaGeneros.Add(objGenero);
                }
            }
            conn.Close();

            return listaGeneros;
        }
    }
}
