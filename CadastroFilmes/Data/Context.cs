using CadastroFilmes.Data.Maps;
using CadastroFilmes.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroFilmes.Data
{
    public class Context : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        //Configurando a string de conexão para o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=APIFilmes;Integrated Security=False;User ID=sa;Password=123456;");
        }

        //mapeando as classes para o esquema do banco de dados
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new FilmeMap());
            builder.ApplyConfiguration(new GeneroMap());
            builder.ApplyConfiguration(new LocacaoMap());

        }


    }
}
