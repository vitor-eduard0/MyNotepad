namespace MyNotepad.Classes
{
    public class Nota
    {
        public int? codigo { get; set; }
        public string? titulo { get; set; }
        public string? conteudo { get; set; }
        public int? operador { get; set; }
        public bool? ativo { get; set; }
        public DateTime? dataCriacao { get; set; }
    }
}