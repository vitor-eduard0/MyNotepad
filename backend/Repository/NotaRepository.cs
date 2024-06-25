using MyNotepad.Classes;
using MyNotepad.DAO;

namespace MyNotepad.Repository
{
    public class NotaRepository : NotaDao
    {
        public NotaRepository(string connectionString) : base(connectionString) { }

        public void inserir(Nota nota)
        {
            base.inserir(nota);
        }
    }
}
