using CadastroFilmes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroFilmes.Data.Maps
{
    public class LocacaoMap : IEntityTypeConfiguration<Locacao>
    {
        //mapeiando a entidade para direcionar para um banco de dados
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("Locacao"); //informando a tabela para o mapeamento
            builder.HasKey(x => x.LocacaoId); //Definindo a chave primaria
            builder.Property(x => x.CPFCliente).IsRequired().HasMaxLength(14).HasColumnType("varchar(14)");
            builder.Property(x => x.DataLocacao).IsRequired().HasColumnType("DateTime");
            builder.HasMany(e => e.Filmes); //Configurando a relação em que uma locação pode ter vários filmes

        }
    }
}

