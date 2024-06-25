using MySql.Data.MySqlClient;

namespace MyNotepad.Classes
{
    public class ConexaoBD
    {
        private string _connectionString { get; set; }
        public ConexaoBD(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection listarConexao()
        {
            return new MySqlConnection(_connectionString);
        }
    }

    public static class ExtensaoBD
    {
        public static object valorOuDbNull(this object? valor)
        {
            if(valor == null)
                return DBNull.Value;
            return valor;
        }
    }
}