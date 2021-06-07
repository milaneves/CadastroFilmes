using System;
using System.Collections.Generic;

namespace CadastroFilmes.Models
{
    public class Locacao
    {
        public int LocacaoId { get; set; }        
        public string CPFCliente { get; set; }
        public DateTime DataLocacao { get; set; }
        public ICollection<FilmeLocacao> Filmes { get; set; }

    }
}
