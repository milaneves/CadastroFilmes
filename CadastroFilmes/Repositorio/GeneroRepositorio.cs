using CadastroFilmes.Data;
using CadastroFilmes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CadastroFilmes.Repositorio
{
    public class GeneroRepositorio
    {
        private readonly Context _context;
        private DbSet<Genero> _dbset { get; set; }

        public GeneroRepositorio(Context context)
        {
            _context = context;
            _dbset = _context.Set<Genero>();
        }

        public IEnumerable<Genero> GetAll()
        {
            return _context.Generos.ToList();
        }

        public Genero Get(int id)
        {
            return _context.Generos.Where(f => f.Id == id).FirstOrDefault();
        }


        public void Create(Genero genero)
        {
            _context.Generos.Add(genero);
            _context.SaveChanges();
        }
    }
}
