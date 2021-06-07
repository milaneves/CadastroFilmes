using CadastroFilmes.Data;
using CadastroFilmes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CadastroFilmes.Repositorio
{
    public class FilmeRepositorio
    {

        private readonly Context _context;

        public FilmeRepositorio (Context context)
        {
            _context = context;
        }
        //Obtendo todos os filmes da tabela
        public IEnumerable<Filme> GetAll()
        {
            return _context.Filmes.ToList(); 
        }

        //Obtendo por Id os filmes da tabela
        public Filme GetById(int id)
        {
            return _context.Filmes.Where(f => f.FilmeId == id).FirstOrDefault();
        }

        //Adiconando um filme na tabela passando o objeto filme
        public void Create(Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
        }

        //Atualizando um filme na tabela passando o objeto filme
        public void Update(Filme filme)
        {
            _context.Entry(filme).State = EntityState.Modified;  
            _context.SaveChanges();
        }

        public void Delete(Filme filme)
        {
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
        }

        //Deletando uma lista de filmes
        public void DeleteAll()
        { 
            var listafilmes = _context.Filmes.Where(f => f.Ativo == 0).ToList();
            _context.Filmes.RemoveRange(listafilmes);
            _context.SaveChanges();
         
        }
        public void GetListIds(int[] ids)
        {
          var  Lista =  _context.Filmes.AsNoTracking().Where(p => ids.Any(x => x == p.FilmeId)).ToList();
            foreach (var remover in Lista)
            {
                var _filme = GetById(remover.FilmeId);
                _context.Filmes.Remove(_filme);

            }
        }
    }
}
