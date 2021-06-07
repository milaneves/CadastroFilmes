namespace CadastroFilmes.Models
{
    public class FilmeLocacao
    {
        public int Id { get; set; }
        public int LocacaoId { get; set; }
        public Filme Filme { get; set; }
    }
}
