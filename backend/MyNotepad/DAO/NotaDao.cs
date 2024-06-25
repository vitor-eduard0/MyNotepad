using MyNotepad.Classes;
using MySql.Data.MySqlClient;

namespace MyNotepad.DAO
{
    public class NotaDao : ConexaoBD
    {
        public NotaDao(string connectionString) : base(connectionString) { }

        protected void inserir(Nota nota)
        {
            using (MySqlConnection conexao = listarConexao())
            {
                using (MySqlCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "P_INSERIR_NOTA";
                        cmd.Parameters.AddWithValue("P_TITULO", nota.titulo);
                        cmd.Parameters.AddWithValue("P_CONTEUDO", nota.conteudo.valorOuDbNull());
                        cmd.Parameters.AddWithValue("P_OPERADOR", nota.operador);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 90;

                        conexao.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        conexao.Close();
                    }
                }
            }
        }
    }
}