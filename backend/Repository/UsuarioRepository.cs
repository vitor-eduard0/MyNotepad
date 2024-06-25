using MyNotepad.Classes;
using MyNotepad.DAO;

namespace MyNotepad.Repository
{
    public class UsuarioRepository : UsuarioDao
    {
        public UsuarioRepository(string connectionString) : base(connectionString) { }

        public List<Usuario> listar(Usuario usuarioParam)
        {
            return base.listar(usuarioParam);
        }
    }
}
