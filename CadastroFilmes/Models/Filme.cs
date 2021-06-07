using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroFilmes.Models
{
    public class Filme
    {
        [Key]
        public int FilmeId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Ativo { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }

    }
}
