namespace MyNotepad.Classes
{
    public class Usuario
    {
        public int? codigo { get; set; }
        public string? nome { get;set; }
        public string? userName { get; set; }
        public string? senha { get; set; }
        public bool? ativo { get; set; }
        public DateTime? dataCriacao { get; set; }
        public string? token { get; set; }
    }
}
