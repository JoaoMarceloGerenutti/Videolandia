using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ItemDAL
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbVideolandia;Integrated Security=True";

        public void InserirItem(Item objItem)
        {
            // Criar um objeto do tipo conexão SQL.
            SqlConnection conn = new SqlConnection(connectionString);

            // Abrir conexão com o Banco de Dados.
            conn.Open();

            // Criar comando sql para inserção.
            string sql = "INSERT INTO Items VALUES (@codigoBarra, @titulo, @generos, @lancamento," +
                " @tipo, @preco, @dataAquisicao, @valor, @situacao, @atores, @diretor, @capa)";

            // Criar um objeto do tipo Comando SQL.
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Trocar os parametros do Comando(@codigoBarra por exemplo) pelas variaveis do objItem.
            cmd.Parameters.AddWithValue("@codigoBarra", objItem.CodigoBarra);
            cmd.Parameters.AddWithValue("@titulo", objItem.Titulo);
            cmd.Parameters.AddWithValue("@generos", DBNull.Value);
            cmd.Parameters.AddWithValue("@lancamento", objItem.Lancamento);
            cmd.Parameters.AddWithValue("@tipo", objItem.Tipo);
            cmd.Parameters.AddWithValue("@preco", objItem.Preco);
            cmd.Parameters.AddWithValue("@dataAquisicao", objItem.DataAquisicao);
            cmd.Parameters.AddWithValue("@valor", objItem.Valor);
            cmd.Parameters.AddWithValue("@situacao", objItem.Situacao);
            cmd.Parameters.AddWithValue("@atores", DBNull.Value);
            cmd.Parameters.AddWithValue("@diretor", objItem.Diretor);
            cmd.Parameters.AddWithValue("@capa", objItem.Capa);

            // Mandar executar o codigo no Banco de Dados.
            cmd.ExecuteNonQuery();

            // Executar a edição do Item para adicionar o Codigo do Genero e Codigo do Ator (Que é igual ao Codigo gerado automaticamente).
            AtualizarCodigosItem(conn);

            // Fechar a conexão com o SQL.
            conn.Close();
        }

        private void AtualizarCodigosItem(SqlConnection conexao)
        {
            // Obtendo o codigo do ultimo item adicionado.
            string ultimoCodigo = "SELECT MAX(Codigo) AS Codigo FROM Items";

            SqlCommand cmd = new SqlCommand(ultimoCodigo, conexao);

            SqlDataReader dr = cmd.ExecuteReader();

            int codigo = 0;
            if (dr.HasRows && dr.Read())
            {
                codigo = Convert.ToInt32(dr["Codigo"]);
            }
            dr.Close();

            // Atualizando o CodigoGenero e CodigoArtista para o Codigo do ultimo genero adicionado.
            string sql = "UPDATE Items SET CodigoGenero = Codigo, CodigoArtista = Codigo WHERE Codigo = @codigo";

            cmd = new SqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@codigo", codigo);

            cmd.ExecuteNonQuery();
        }

        public int ObterCodigoUltimoItem()
        {
            // Criar um objeto do tipo conexão SQL.
            SqlConnection conn = new SqlConnection(connectionString);

            // Abrir conexão com o Banco de Dados.
            conn.Open();

            // Obtendo o codigo do ultimo item adicionado.
            string ultimoCodigo = "SELECT MAX(Codigo) AS Codigo FROM Items";

            SqlCommand cmd = new SqlCommand(ultimoCodigo, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            int codigo = 0;
            if (dr.HasRows && dr.Read())
            {
                codigo = Convert.ToInt32(dr["Codigo"]);
            }

            conn.Close();

            return codigo;
        }

        public void InserirGenerosItem(int codigoItem, int codigoGenero)
        {
            // Criar um objeto do tipo conexão SQL.
            SqlConnection conn = new SqlConnection(connectionString);

            // Abrir conexão com o Banco de Dados.
            conn.Open();

            // Criar comando sql para inserção.
            string sql = "INSERT INTO Contem VALUES (@codigoItem, @codigoGenero)";

            // Criar um objeto do tipo Comando SQL.
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Trocar os parametros do Comando(@codigoItem por exemplo) pelas variaveis.
            cmd.Parameters.AddWithValue("@codigoItem", codigoItem);
            cmd.Parameters.AddWithValue("@codigoGenero", codigoGenero);

            // Mandar executar o codigo no Banco de Dados.
            cmd.ExecuteNonQuery();

            // Fechar a conexão com o SQL.
            conn.Close();
        }

        public void InserirAtoresItem(int codigoItem, int codigoAtor, string nomePersonagem)
        {
            // Criar um objeto do tipo conexão SQL.
            SqlConnection conn = new SqlConnection(connectionString);

            // Abrir conexão com o Banco de Dados.
            conn.Open();

            // Criar comando sql para inserção.
            string sql = "INSERT INTO Atua VALUES (@CodigoItem, @CodigoArtista, @NomePersonagem)";

            // Criar um objeto do tipo Comando SQL.
            SqlCommand cmd = new SqlCommand(sql, conn);

            // Trocar os parametros do Comando(@codigoItem por exemplo) pelas variaveis.
            cmd.Parameters.AddWithValue("@codigoItem", codigoItem);
            cmd.Parameters.AddWithValue("@CodigoArtista", codigoAtor);
            cmd.Parameters.AddWithValue("@NomePersonagem", nomePersonagem);

            // Mandar executar o codigo no Banco de Dados.
            cmd.ExecuteNonQuery();

            // Fechar a conexão com o SQL.
            conn.Close();
        }

        public Item[] ObterItemPorData()
        {
            Item[] arrayItem = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Items ORDER BY DataAquisicao DESC";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                arrayItem = new Item[10];

                for (int i = 0; i < 10; i++)
                {
                    if (dr.Read())
                    {
                        Item objItem = new Item();

                        objItem.Codigo = Convert.ToInt32(dr["Codigo"]);
                        objItem.CodigoBarra = dr["CodigoBarra"].ToString();
                        objItem.Titulo = dr["Titulo"].ToString();
                        objItem.Lancamento = Convert.ToDateTime(dr["Lancamento"]);
                        objItem.Tipo = Convert.ToBoolean(dr["Tipo"]);
                        objItem.Preco = Convert.ToSingle(dr["Preco"]);
                        objItem.DataAquisicao = Convert.ToDateTime(dr["DataAquisicao"]);
                        objItem.Valor = Convert.ToSingle(dr["Valor"]);
                        objItem.Situacao = Convert.ToBoolean(dr["Situacao"]);
                        objItem.Diretor = dr["Diretor"].ToString();
                        objItem.Capa = dr["Capa"].ToString();

                        arrayItem[i] = objItem;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayItem;
        }

        public Item ProcurarItemCodigo(int codigoItem)
        {
            Item objItem = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Items WHERE Codigo = @codigoItem";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@codigoItem", codigoItem);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows && dr.Read())
            {
                objItem = new Item();

                objItem.Codigo = Convert.ToInt32(dr["Codigo"]);
                objItem.CodigoBarra = dr["CodigoBarra"].ToString();
                objItem.Titulo = dr["Titulo"].ToString();
                objItem.Lancamento = Convert.ToDateTime(dr["Lancamento"]);
                objItem.Tipo = Convert.ToBoolean(dr["Tipo"]);
                objItem.Preco = Convert.ToSingle(dr["Preco"]);
                objItem.DataAquisicao = Convert.ToDateTime(dr["DataAquisicao"]);
                objItem.Valor = Convert.ToSingle(dr["Valor"]);
                objItem.Situacao = Convert.ToBoolean(dr["Situacao"]);
                objItem.Diretor = dr["Diretor"].ToString();
                objItem.Capa = dr["Capa"].ToString();
            }
            conn.Close();

            return objItem;
        }

        public Item[] ProcurarItems()
        {
            Item[] arrayItem = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Items ORDER BY Titulo";

            SqlCommand cmd = new SqlCommand(sql, conn);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                arrayItem = new Item[10];

                for (int i = 0; i < 10; i++)
                {
                    if (dr.Read())
                    {
                        Item objItem = new Item();

                        objItem.Codigo = Convert.ToInt32(dr["Codigo"]);
                        objItem.CodigoBarra = dr["CodigoBarra"].ToString();
                        objItem.Titulo = dr["Titulo"].ToString();
                        objItem.Lancamento = Convert.ToDateTime(dr["Lancamento"]);
                        objItem.Tipo = Convert.ToBoolean(dr["Tipo"]);
                        objItem.Preco = Convert.ToSingle(dr["Preco"]);
                        objItem.DataAquisicao = Convert.ToDateTime(dr["DataAquisicao"]);
                        objItem.Valor = Convert.ToSingle(dr["Valor"]);
                        objItem.Situacao = Convert.ToBoolean(dr["Situacao"]);
                        objItem.Diretor = dr["Diretor"].ToString();
                        objItem.Capa = dr["Capa"].ToString();

                        arrayItem[i] = objItem;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayItem;
        }

        public Item[] ProcurarItems(string busca)
        {
            Item[] arrayItem = null;

            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM Items WHERE Titulo LIKE @titulo";

            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@titulo", "%" + busca + "%");

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                arrayItem = new Item[10];

                for (int i = 0; i < 10; i++)
                {
                    if (dr.Read())
                    {
                        Item objItem = new Item();

                        objItem.Codigo = Convert.ToInt32(dr["Codigo"]);
                        objItem.CodigoBarra = dr["CodigoBarra"].ToString();
                        objItem.Titulo = dr["Titulo"].ToString();
                        objItem.Lancamento = Convert.ToDateTime(dr["Lancamento"]);
                        objItem.Tipo = Convert.ToBoolean(dr["Tipo"]);
                        objItem.Preco = Convert.ToSingle(dr["Preco"]);
                        objItem.DataAquisicao = Convert.ToDateTime(dr["DataAquisicao"]);
                        objItem.Valor = Convert.ToSingle(dr["Valor"]);
                        objItem.Situacao = Convert.ToBoolean(dr["Situacao"]);
                        objItem.Diretor = dr["Diretor"].ToString();
                        objItem.Capa = dr["Capa"].ToString();

                        arrayItem[i] = objItem;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            conn.Close();

            return arrayItem;
        }
    }
}
