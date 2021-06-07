using CadastroFilmes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroFilmes.Data.Maps
{
    public class FilmeMap : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("Filme");
            builder.HasKey(x => x.FilmeId);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200).HasColumnType("varchar(200)");
            builder.Property(x => x.DataCriacao).HasColumnType("DateTime");
            builder.HasOne(x => x.Genero); //Configurando a relação em que um filme tem um genero


        }
    }
}

