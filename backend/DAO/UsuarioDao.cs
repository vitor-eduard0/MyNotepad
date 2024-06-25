using MyNotepad.Classes;
using MySql.Data.MySqlClient;

namespace MyNotepad.DAO
{
    public class UsuarioDao : ConexaoBD
    {
        public UsuarioDao(string connectionString) : base(connectionString) { }

        protected List<Usuario> listar(Usuario usuarioParam)
        {
            using(MySqlConnection conexao = listarConexao())
            {
                using(MySqlCommand cmd = conexao.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "P_LISTAR_USUARIO";
                        cmd.Parameters.AddWithValue("P_CODIGO", usuarioParam.codigo.valorOuDbNull());
                        cmd.Parameters.AddWithValue("P_USERNAME", usuarioParam.userName.valorOuDbNull());
                        cmd.Parameters.AddWithValue("P_SENHA", usuarioParam.senha.valorOuDbNull());
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.CommandTimeout = 90;

                        conexao.Open();
                        MySqlDataReader leitor = cmd.ExecuteReader();

                        List<Usuario> usuarios = new List<Usuario>();
                        while (leitor.Read())
                        {
                            Usuario usuario = new Usuario();
                            usuario.codigo = Convert.ToInt32(leitor["CODIGO"]);
                            usuario.nome = leitor["NOME"].ToString();
                            usuario.userName = leitor["USERNAME"].ToString();
                            usuario.senha = leitor["SENHA"].ToString();
                            usuario.ativo = Convert.ToBoolean(leitor["ATIVO"]);
                            usuario.dataCriacao = Convert.ToDateTime(leitor["DATACRIACAO"]);
                            usuarios.Add(usuario);
                        }
                        return usuarios;
                    }
                    catch(Exception ex)
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
